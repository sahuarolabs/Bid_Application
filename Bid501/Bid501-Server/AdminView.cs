using Bid501_Shared;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using WebSocketSharp;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Server
{
    public partial class AdminView : Form
    {
        private AddProduct addProduct;
        private ProductModel model;
        private AccountModel account;
        private BidEnded bidChanged;
        List<string> accounts = new List<string>();
        List<Product> products = new List<Product>();

        private Product product;
        List<string> actives = new List<string>();
        public AdminView( BidEnded be, AddProduct ap, ProductModel pm, AccountModel am)
        {
            InitializeComponent();
            this.bidChanged = be;   
            this.addProduct = ap;
            account = am;
            this.model = pm;
            products = model.Sync();
            accounts = account.activeUsersList;
            activeClientList.DataSource = null;
            if (actives != null)
            {
                //activeClientList.DataSource = accounts;
                foreach (string accountName in actives)
                {
                    if (activeClientList.InvokeRequired)
                    {
                        activeClientList.Invoke((MethodInvoker)delegate ()
                        {
                            activeClientList.Items.Clear();
                            activeClientList.Items.Add(accountName);
                        });
                    }
                }
            }
            activeProductList.DataSource = null;
            activeClientList.DataSource = null;

            activeProductList.DataSource = products;
            activeClientList.DataSource = actives;

            ServerCommControl.OnNewMessage += ServerCommControl_OnNewMessage;
        }
        public void AdminOpen()
        {
            //activeProductList.DataSource = null;
            //activeClientList.DataSource = null;

            //activeProductList.DataSource = products;
            //activeClientList.DataSource = actives;

            this.ShowDialog();
            activeClientList.DataSource = null;
            accounts = account.activeUsersList;
            if (actives != null)
            {
                //activeClientList.DataSource = accounts;
                foreach (string accountName in actives)
                {
                    if (activeClientList.InvokeRequired)
                    {
                        activeClientList.Invoke((MethodInvoker)delegate ()
                        {
                            activeClientList.Items.Clear();
                            activeClientList.Items.Add(accountName);
                        });
                    }
                }
            }
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
        }
        public void Resync()
        {
            products = model.Sync();
            accounts = account.activeUsersList;
            activeClientList.DataSource = null;
            if (actives != null)
            {
                //activeClientList.DataSource = accounts;
                foreach (string accountName in actives)
                {
                    if (activeClientList.InvokeRequired)
                    {
                        activeClientList.Invoke((MethodInvoker)delegate ()
                        {
                            activeClientList.Items.Clear();
                            activeClientList.Items.Add(accountName);
                        });
                    }
                }
            }
            activeProductList.DataSource = null;
            activeClientList.DataSource = null;

            products = model.Sync();

            activeProductList.DataSource = products;
            activeClientList.DataSource = actives;
        }
        private void activeProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(activeProductList.SelectedIndex != -1)
            {
                int index = activeProductList.SelectedIndex;
                product = products[index];
            }
            else
            {
                product = (Product)activeProductList.Items[0];
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            addProduct();
        }

        private void uxEndBidBtn_Click(object sender, EventArgs e)
        {
            Product changeBid = product;
            bidChanged(changeBid);  
        }

        private void ServerCommControl_OnNewMessage(object sender, NewMessageEventArgs e)
        {
            if(e.LogData == "Logout")
            {
                this?.Invoke(new Action(() =>
                {
                    activeClientList.DataSource = null;
                    actives.Remove(e.Username);
                    activeClientList.DataSource = actives;
                }));
            }
            else
            {
                this?.Invoke(new Action(() =>
                {
                    activeClientList.DataSource = null;
                    actives.Add(e.Username);
                    activeClientList.DataSource = actives;
                }));
            }
        }
    }
}

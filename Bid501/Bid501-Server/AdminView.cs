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
        List<Account> actives = new List<Account>();
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
            if (accounts != null)
            {
                //activeClientList.DataSource = accounts;
                foreach (string accountName in accounts)
                {
                    if (activeClientList.InvokeRequired)
                    {
                        activeClientList.Invoke((MethodInvoker)delegate ()
                        {

                            activeClientList.Items.Add(accountName);
                        });
                    }
                }
            }
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
            
        }
        public void AdminOpen()
        {
            this.ShowDialog();
            activeClientList.DataSource = null;
            accounts = account.activeUsersList;
            if (accounts != null)
            {
                //activeClientList.DataSource = accounts;
                foreach (string accountName in accounts)
                {
                    if (activeClientList.InvokeRequired)
                    {
                        activeClientList.Invoke((MethodInvoker)delegate ()
                        {

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
            if (accounts != null)
            {
                //activeClientList.DataSource = accounts;
                foreach (string accountName in accounts)
                {
                    if (activeClientList.InvokeRequired)
                    {
                        activeClientList.Invoke((MethodInvoker)delegate ()
                        {

                            activeClientList.Items.Add(accountName);
                        });
                    }
                }
            }
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
        }
        private void activeProductList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            addProduct();
        }

        private void uxEndBidBtn_Click(object sender, EventArgs e)
        {
           Product changeBid = (Product)activeProductList.SelectedItem;
            bidChanged(changeBid);  

        }
    }
}

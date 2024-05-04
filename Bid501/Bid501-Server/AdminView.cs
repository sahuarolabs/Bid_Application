using Bid501_Shared;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
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
        private BidEnded bidChanged;
        List<Product> products = new List<Product>();
        List<string> actives = new List<string>();
        public AdminView( BidEnded be, AddProduct ap, ProductModel pm, AccountModel am)
        {
            InitializeComponent();
            this.bidChanged = be;   
            this.addProduct = ap;   
            this.model = pm;
            products = model.Sync();
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
            
        }
        public void Resync()
        {
            activeProductList.DataSource = null;
            activeClientList.DataSource = null;

            products = model.Sync();

            activeProductList.DataSource = products;
            activeClientList.DataSource = actives;
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

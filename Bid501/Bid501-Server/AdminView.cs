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
        private static List<string> actives = new List<string>();
        public AdminView( BidEnded be, AddProduct ap, ProductModel pm, AccountModel am)
        {
            InitializeComponent();
            this.bidChanged = be;   
            this.addProduct = ap;   
            this.model = pm;
            products = model.Sync();
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;

            ServerCommControl.OnNewMessage += ServerCommControl_OnNewMessage;

            activeClientList.DataSource = null;
            activeClientList.DataSource = actives;

        }
        public void AdminOpen()
        {
            this.ShowDialog();
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
            activeClientList.DataSource = null;
            activeClientList.DataSource = actives;
        }
        public void Resync()
        {
            products = model.Sync();
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
            activeClientList.DataSource = null;
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
            actives.Add(e.Username);
        }
    }
}

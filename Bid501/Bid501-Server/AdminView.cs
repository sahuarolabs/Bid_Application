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
        List<Account> actives = new List<Account>();
        public AdminView( BidEnded be, AddProduct ap, ProductModel pm, AccountModel am)
        {
            InitializeComponent();
            this.bidChanged = be;   
            this.addProduct = ap;   
            this.model = pm;
            products = model.Sync();
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
            
        }
        public void AdminOpen()
        {
            this.ShowDialog();
            activeProductList.DataSource = null;
            activeProductList.DataSource = products;
        }
        public void Resync()
        {
            products = model.Sync();
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

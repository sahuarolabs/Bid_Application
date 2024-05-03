using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Server
{
    public partial class AddProductView : Form
    {
        ProductModel model;
        SendServerProduct ssp;
        List<Product> products = new List<Product>();
        public AddProductView(SendServerProduct p, ProductModel m)
        {
            this.ssp = p;   
            this.model = m;
            InitializeComponent();
            products = model.SyncHardcoded();
            productList.DataSource = null;
            productList.DataSource = products;
        }
   
        public void AddProduct()
        {
            this.ShowDialog();
            productList.DataSource = null;
            productList.DataSource = products;
            if(products.Count == 0 ) { addProductButton.Enabled = false; }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
           model.ProductModelAdd((Product)productList.SelectedItem);
           model.RemoveHardcoded((Product)productList.SelectedItem);
            ssp((Product)productList.SelectedItem);
           this.Close();
        }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

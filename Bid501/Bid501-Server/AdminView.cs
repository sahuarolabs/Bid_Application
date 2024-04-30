using Bid501_Shared;
using System;
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
        List<Product> products = new List<Product>();
        public AdminView( AddProduct ap, ProductModel pm)
        {
            InitializeComponent();
            this.addProduct = ap;   
            this.model = pm;
            products = model.Sync();
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
    }
}

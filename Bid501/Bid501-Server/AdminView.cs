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

        public AdminView( AddProduct ap)
        {
            InitializeComponent();
            Product iphone = new Product("IPhone XS", 001, DateTime.Now, true);
            Product coffeeMug = new Product("Coffee Mug", 002, DateTime.Now, false);
            Product computer = new Product("Computer", 003, DateTime.Now, true);
            this.addProduct = ap;   
            List<Product> products = new List<Product>();
            products.Add(iphone);
            products.Add(coffeeMug);
            products.Add(computer);
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

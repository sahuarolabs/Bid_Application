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
    public partial class AddProductView : Form
    {
        ProductModel model;
        List<Product> products = new List<Product>();
        public AddProductView(ProductModel m)
        {
            this.model = m;
            InitializeComponent();
            Product waterBottle = new Product("WaterBottle", 004, DateTime.Now, true);
            Product calculator = new Product("Calculator", 006, DateTime.Now, true);
            Product miniProjector = new Product("Mini Projector", 008, DateTime.Now, true);
            
            
            products.Add(waterBottle);
            products.Add(calculator);   
            products.Add(miniProjector);
            productList.DataSource = null;
            productList.DataSource = products;
        }

        public void AddProduct()
        {
            this.ShowDialog();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
           model.ProductModelAdd((Product)productList.SelectedItem);
           this.Close();
        }
     


        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

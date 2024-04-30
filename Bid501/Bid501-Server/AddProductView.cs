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
        public AddProductView()
        {
           InitializeComponent();
           Product waterBottle = new Product("Computer", 004, DateTime.Now, true);
            List<Product> products = new List<Product>();
            products.Add(waterBottle);
            productList.DataSource = null;
            productList.DataSource = products;
        }

        public void AddProductDel()
        {
            this.ShowDialog();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {

        }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

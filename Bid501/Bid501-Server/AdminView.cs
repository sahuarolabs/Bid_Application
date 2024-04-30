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
        public AdminView()
        {
            InitializeComponent();
            Product iphone = new Product("IPhone XS", 001, DateTime.Now, true);
            Product coffeeMug = new Product("Coffee Mug", 002, DateTime.Now, false);
            Product computer = new Product("Computer", 003, DateTime.Now, true);

            List<Product> products = new List<Product>();
            products.Add(iphone);
            products.Add(coffeeMug);
            products.Add(computer);
            foreach(Product product in products)
            {
                //activeProductList.ControlAdded()
            }

        }

        private void activeProductList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

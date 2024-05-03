using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Client
{
    public delegate void SendBidToController(IProduct product, double bid);
    public delegate void logoutUserViewDel();
    public partial class ClientView : Form
    {
        private List<Product_Proxy> listOfProducts;
        public SendBidToController sendBid { get; set; }
        public logoutUserViewDel logoutUser { get; set; }
        Product_ProxyDB pdb;
        public ClientView(Product_ProxyDB pdb)
        {
            InitializeComponent();
            this.Visible = false;
            this.pdb = pdb;
        }
        public void PopulateView()
        {
            listOfProducts = pdb.PL;
           
            UxItemName.Text = listOfProducts[0].Name;
            UxTimeLeft.Text = listOfProducts[0].Time.ToString();
            switch (listOfProducts[0].Status.ToString())
            {
                case "Available":
                    UxStatus.BackColor = Color.Blue;
                    break;
                case "Unavailable":
                    UxStatus.BackColor = Color.Red;
                    break;
            }
          //  UxAmountBids.Text = listOfProducts[0].bidHistory.Count.ToString();
            UxMinBid.Text = "Minimum bid $" + listOfProducts[0].Price.ToString();
       
        }
        public void UpdateList()
        {
            foreach(Product_Proxy p in listOfProducts)
            {
                UxListView.Items.Add(p.Name);
            }
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UxListView.SelectedItems.Count == 1)
            {
                sendBid(listOfProducts[UxListView.Items.IndexOf(UxListView.SelectedItems[0])], Convert.ToDouble(UxBidAmt));
            }
        }

        private void ClientView_FormClosing(object sender, FormClosingEventArgs e)
        {
            logoutUser();
        }

        public void ChangeVisibility()
        {
            if (this.Visible == true) this.Visible = false;
            else this.Visible = true;
        }
    }
}

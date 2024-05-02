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
    public partial class ClientView : Form
    {
        private List<IProduct> listOfProducts;
        public SendBidToController sendBid { get; set; }
        public ClientView()
        {
            InitializeComponent();
        }
        public void PopulateView()
        {
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
            UxAmountBids.Text = listOfProducts[0].bidHistory.Count.ToString();
            UxMinBid.Text = "Minimum bid $" + listOfProducts[0].bidHistory[listOfProducts[0].bidHistory.Count - 1].ToString();
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
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bid501_Client
{
    public delegate void SendBidToController(Product_Proxy product, double bid);
    public delegate void logoutUserViewDel();
    public partial class ClientView : Form
    {
        private List<Product_Proxy> listOfProducts;
        public SendBidToController sendBid { get; set; }
        public logoutUserViewDel logoutUser { get; set; }
        Product_ProxyDB pdb;
        private int curIndex = 0;
        public ClientView(Product_ProxyDB pdb)
        {
            InitializeComponent();
            this.Visible = false;
            this.pdb = pdb;
        }
        public void PopulateView(int ind)
        {
            listOfProducts = pdb.PL;
           
            UxItemName.Text = listOfProducts[ind].Name;
            UxTimeLeft.Text = listOfProducts[ind].Time.ToString();
            switch (listOfProducts[ind].Status.ToString())
            {
                case "Available":
                    UxStatus.BackColor = Color.Blue;
                    break;
                case "Unavailable":
                    UxStatus.BackColor = Color.Red;
                    break;
            }
            //UxAmountBids.Text = listOfProducts[ind]
            UxAmountBids.Text = "(x bids)";
            UxMinBid.Text = "Minimum bid $" + listOfProducts[ind].Price.ToString();
            UpdateList();
       
        }
        public void UpdateList()
        {
            UxListView.ClearSelected();
            foreach(Product_Proxy p in listOfProducts)
            {
                //UxListView.Items.Add(p.Name);
                if (UxListView.InvokeRequired)
                {
                    UxListView.Invoke((MethodInvoker)delegate ()
                    {
                        ListViewItem item = new ListViewItem(p.Name);
                        UxListView.Items.Add(item.Text.ToString());
                        //UxListView.EnsureVisible(UxListView.Items.Count - 1);
                    });
                }

                //this.Invoke(new Action(() =>
                //{
                //    UxListView.Items.Add(p.Name);
                //}));

            }
            //PopulateView(curIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sendBid(listOfProducts[curIndex], Convert.ToDouble(UxBidAmt.Text));
            }
            catch
            {
                MessageBox.Show("Invalid Bid Price");
            }
            
        }

        public void ChangeVisibility()
        {
            if (this.Visible == true) this.Visible = false;
            else this.Visible = true;
        }

        private void UxListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            curIndex = UxListView.SelectedIndex;
            PopulateView(UxListView.SelectedIndex);
        }

        private void ClientView_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            logoutUser();
        }
    }
}

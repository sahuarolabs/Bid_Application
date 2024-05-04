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
        public void PopulateView()
        {
            try
            {
                listOfProducts = pdb.PL;

                UxItemName.Text = listOfProducts[curIndex].Name;
                UxTimeLeft.Text = listOfProducts[curIndex].Time.ToString();
                if (listOfProducts[curIndex].Status)
                {
                    UxStatus.BackColor = Color.Blue;
                }
                else
                {
                    UxStatus.BackColor = Color.Red;

                }
                //UxAmountBids.Text = listOfProducts[ind]
                //UxAmountBids.Text = "(x bids)";
                //UxStatus.BackColor = Color.Blue;
                UxMinBid.Text = "Minimum bid $" + listOfProducts[curIndex].Price.ToString();
            }
            catch
            {
                MessageBox.Show("Invalid Selection");
            }
            //UpdateList();
       
        }

        public void UpdateList()
        {
            if (UxListView.InvokeRequired)
            {
                UxListView.Invoke((MethodInvoker)delegate ()
                {
                    UxListView.Items.Clear();
                });
            }
            else
            {
                UxListView.Items.Clear();
            }

            foreach (Product_Proxy p in pdb.PL)
            {
                if (UxListView.InvokeRequired)
                {
                    UxListView.Invoke((MethodInvoker)delegate ()
                    {
                        ListViewItem item = new ListViewItem(p.Name);
                        UxListView.Items.Add(item.Text.ToString());
                        UxAmountBids.Text = listOfProducts[curIndex].Bidders.ToString();
                    });
                }
                else
                {
                    UxListView.Items.Add(p.Name);
                }
            }
            listOfProducts = pdb.PL;
            try
            {
                UxItemName.Text = listOfProducts[curIndex].Name;
                UxTimeLeft.Text = listOfProducts[curIndex].Time.ToString();
                if (listOfProducts[curIndex].Status)
                {
                    UxStatus.BackColor = Color.Blue;
                }
                else
                {
                    if (UxListView.InvokeRequired)
                    {
                        UxListView.Invoke((MethodInvoker)delegate ()
                        {
                            UxStatus.BackColor = Color.Red;
                        });
                    }
                    else
                    {
                        UxStatus.BackColor = Color.Red;
                    }

                }
                //UxAmountBids.Text = "(x bids)";
                if (UxListView.InvokeRequired)
                {
                    UxListView.Invoke((MethodInvoker)delegate ()
                    {
                        UxMinBid.Text = "Minimum bid $" + listOfProducts[curIndex].Price.ToString();
                    });
                }
                else
                {
                    UxMinBid.Text = "Minimum bid $" + listOfProducts[curIndex].Price.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Selection");
            }

            
            
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
            PopulateView();
        }

        private void ClientView_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            logoutUser();
        }

        public void NotifyBidEnded(string name, string itemName, double price)
        {
            MessageBox.Show(name + " has won " + itemName + " at $" + price);
        }
    }
}

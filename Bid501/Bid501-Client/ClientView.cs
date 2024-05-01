﻿using System;
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
    public partial class ClientView : Form
    {
        private List<IProduct> listOfProducts;
        public ClientView()
        {
            PopulateView();
            InitializeComponent();
        }
        private void PopulateView()
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
        public void UpdateList(List<IProduct> pList)
        {
            listOfProducts = pList;
            foreach(Product_Proxy p in pList)
            {
                UxListView.Items.Add(p.Name);
            }
            this.Visible = true;
        }
    }
}

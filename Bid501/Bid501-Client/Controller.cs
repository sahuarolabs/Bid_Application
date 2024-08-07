﻿using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate void ViewUpdateListDel();
    public delegate void SendBid(Product_Proxy p, string username);
    public delegate void ListUpdate();
    public delegate void ListUpdateToServer(Product_Proxy product);
    public delegate void PopulateListView();
    public delegate void LogoutUserDel(string cred);
    public delegate void ReplaceProduct();
    public delegate void NotifyBidEnded(string name, string item, double price);
    public class Controller
    {
        private List<Product_Proxy> productList;
        public Product_ProxyDB product_ProxyDB { get; set; }
        public LoginDel handleLogin { get; set; }
        public SendBid sendBid { get; set; }
        public ListUpdate listUpdate { get; set; }
        public ListUpdateToServer listUpdateToServer { get; set; }
        public PopulateListView populateListView { get; set; }
        public LogoutUserDel logoutUser { get; set; }
        public TurnClientViewOn turnClientViewOn { get; set; }
        public UpdateLoginStatus updateLogin { get; set; }
        public ReplaceProduct replaceProduct { get; set; }
        public NotifyBidEnded notifyBidEnded { get; set; }
        private string cred;
        private bool lockForm = true;
        private string username;
        public void UpdateList(List<Product_Proxy> list)
        {
            product_ProxyDB.PL = list;
            populateListView();
            listUpdate();
            if (lockForm)
            {
                updateLogin(State.SUCCESS);
                lockForm = false;
            }
            
        }

        public List<IProductDB> LogOutHandler(string username)
        {
            return null;
        }

        public void LogInHandler(string cred)
        {
            this.cred = cred;
            handleLogin(cred);
        }

        public void CheckMinBid(Product_Proxy product, double bid)
        {
            if (product.Price < bid)
            {
                product.Price = bid;
                UpdateProduct(product);
                sendBid(product, username);
                populateListView();
            }
        }

        public void UpdateProduct(Product_Proxy product)
        {
            List<Product_Proxy> fakeProductList = product_ProxyDB.PL;
            int ind = 0;
            foreach (Product_Proxy p in fakeProductList)
            {
                if (p.ID == product.ID)
                {
                    if (product_ProxyDB.PL[ind].Status != product.Status && !product.Status)
                    {
                        //notify Client View with price and the status
                        notifyBidEnded(product.HighestBidder, product.Name, product.Price);
                    }
                    product_ProxyDB.PL[ind].Price = product.Price;
                    product_ProxyDB.PL[ind].Status = product.Status;
                    product_ProxyDB.PL[ind].Bidders = product.Bidders;
                    product_ProxyDB.PL[ind].HighestBidder = product.HighestBidder;

                    //replaceProduct();

                }
                ind++;
            }
            ProductListUpdated();

        }

        private void ProductListUpdated()
        {
            listUpdate();
        }

        private void ProductListUpdateToServer(Product_Proxy product)
        {
            listUpdateToServer(product);
        }

        /// <summary>
        /// Adds/Sends that a new product has been added to the list to the view.
        /// </summary>
        /// <param name="product"></param>
        public void NewProduct(Product_Proxy product)
        {
            product_ProxyDB.PL.Add(product);
            ProductListUpdated();
        }

        public void Logout()
        {
            logoutUser(cred);
        }

        public void TurnViewOnClient()
        {
            turnClientViewOn();
        }
        public void SendUsername(string username)
        {
            this.username = username;
        }
    }
}

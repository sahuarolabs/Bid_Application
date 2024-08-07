﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;
using System.Deployment.Application;
using Bid501_Shared;
using WebSocketSharp.Server;
//using System.Text.Json;
using Bid501_Server;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Bid501_Client
{
    public delegate void UpdateLoginStatus(Bid501_Shared.State s);
    public delegate void UpdateProduct(Product_Proxy product);
    public delegate void AddProduct(Product_Proxy product);
    public class ClientCommControl : WebSocketBehavior
    {
        private WebSocket ws;
        public Product_ProxyDB ppd { get; set; }
        public UpdateLoginStatus updateLoginStatus { get; set; }
        public UpdateListDel updateList { get; set; }
        public UpdateProduct updateProduct { get; set; }
        public AddProduct addProduct { get; set; }

        public ClientCommControl()
        {
            //IPAddress localIP = null;
            //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (IPAddress ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        localIP = ip;
            //        break;
            //    }
            //}
            int port = 8001;
            string wsAddress = $"ws://10.130.160.110:{port}/shared";

            this.ws = new WebSocket(wsAddress);

            //ws.Connect();
            //while (ws.ReadyState != WebSocketState.Open)
            //{
            //    port++;
            //    this.ws = new WebSocket(wsAddress);

                
            //}
            ws.Connect();
            OnOpen();
            ws.OnMessage += (sender, e) => { handleCom(e.Data); };
        }

        public void SendLoginCredentials(string cred)
        {
            ws.Send("Login:" + cred);
        }

        public void SendBidItem(Product_Proxy product, string username)
        {
            ws.Send(JsonConvert.SerializeObject(product) + "|" + username);
        }

        public void SendBidItem(Product_Proxy product)
        {
            ws.Send(JsonConvert.SerializeObject(product) + "|" + "");
        }

        public void LogoutUser(string cred)
        {
            try
            {
                ws.Send("Logout:" + cred);
                ws.Close(); //doesnt allow for same computer to connect more than once
            }
            catch
            {
                MessageBox.Show("Connection Unstable!");
            }
        }

        private void UpdateLoginStatus(Bid501_Shared.State s)
        {
            //delegate to show if the username and password was valid.
            updateLoginStatus(s);
        }

        public void handleCom(string e)
        {
            string[] split = e.ToString().Split('|');
            switch (split[0])
            {
                case "Success":
                    List<Product_Proxy> productList = DeserializeProductList(split[1]);
                    updateList(productList);
                    break;
                case "DECLINED":
                    UpdateLoginStatus(Bid501_Shared.State.DECLINED);
                    break;
                case "Update":
                    Product_Proxy productUpdate = DeserializeProduct(split[1]);
                    updateProduct(productUpdate);
                    break;
                case "New":
                    Product_Proxy productNew = DeserializeProduct(split[1]);
                    addProduct(productNew);
                    break;
                case "BidEnded":
                    Product_Proxy productEnded = DeserializeProduct(split[1]);
                    updateProduct(productEnded);
                    break;
            }
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            string[] split = e.ToString().Split('|');
            switch (split[0])
            {
                case "Success":
                    List<Product_Proxy> productList = DeserializeProductList(split[1]);
                    updateList(productList);
                    UpdateLoginStatus(Bid501_Shared.State.SUCCESS);
                    break;
                case "DECLINED":
                    UpdateLoginStatus(Bid501_Shared.State.DECLINED);
                    break;
                case "Update":
                    Product_Proxy productUpdate = DeserializeProduct(split[1]);
                    updateProduct(productUpdate);
                    break;
                case "New":
                    Product_Proxy productNew = DeserializeProduct(split[1]);
                    addProduct(productNew);
                    break;
                case "BidEnded":
                    Product_Proxy productEnded = DeserializeProduct(split[1]);
                    updateProduct(productEnded);
                    break;
            }
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            ws.Send("Connection|" + Dns.GetHostName()); //breaks on second client instance
        }

        private List<Product_Proxy> DeserializeProductList(string s)
        {
            List<Product_Proxy> product_Proxy = JsonConvert.DeserializeObject<List<Product_Proxy>>(s);
            return product_Proxy;
        }

        private Product_Proxy DeserializeProduct(string s)
        {
            Product_Proxy product_Proxy = JsonConvert.DeserializeObject<Product_Proxy>(s);

            return product_Proxy;
            //send the proxy and also make a new view.
        }
    }
}
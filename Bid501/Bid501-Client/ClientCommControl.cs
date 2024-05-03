using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;
using System.Deployment.Application;
using Bid501_Shared;
using WebSocketSharp.Server;
using System.Text.Json;
using Bid501_Server;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Bid501_Client
{
    public delegate void UpdateLoginStatus(Bid501_Shared.State s);
    public delegate void UpdateProduct(Product_Proxy product);
    public delegate void AddProduct(Product_Proxy product);
    public class ClientCommControl : WebSocketBehavior
    {
        private static WebSocket ws = new WebSocket("ws://10.130.160.110:8001/shared");
        public Product_ProxyDB ppd { get; set; }
        public UpdateLoginStatus updateLoginStatus { get; set; }
        public UpdateListDel updateList { get; set; }
        public UpdateProduct updateProduct { get; set; }
        public AddProduct addProduct { get; set; }
        public ClientCommControl(WebSocket ws)
        {
            //this.ws = ws;
        }

        public ClientCommControl()
        {
            ws.Connect();
            ws.OnMessage += (sender, e) => { handleCom(e.Data); };
        }

        public void SendLoginCredentials(string cred)
        {
            ws.Send("Login:" + cred);
        }

        public void SendBidItem(Product_Proxy product)
        {
            ws.Send(JsonConvert.SerializeObject(product));
        }

        public void LogoutUser(string cred)
        {
            ws.Send("Logout:" + cred);
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
<<<<<<< HEAD
                switch (split[1])
                {
                    case "SUCCESS":
                        UpdateLoginStatus(Bid501_Shared.State.SUCCESS);
                        break;
                    case "DECLINED":
                        UpdateLoginStatus(Bid501_Shared.State.DECLINED);
                        break;
                }
            }
            else if (split[0] == "proxy")
            {
                MakeTheSerial(split[1]);
            }
        }

        private void MakeTheSerial(string s)
        {
            Product_Proxie product_Proxy = JsonSerializer.Deserialize<Product_Proxie>(s);
=======
                case "Success":
                    List<Product_Proxy> productList = DeserializeProductList(split[1]);
                    //ppd.PL = productList;
                    updateList(productList);
                    //UpdateLoginStatus(Bid501_Shared.State.SUCCESS);
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

        private List<Product_Proxy> DeserializeProductList(string s)
        {
           //  List<IProduct> product_Proxy = JsonSerializer.Deserialize<List<IProduct>>(s);
            List<Product_Proxy> product_Proxy = JsonConvert.DeserializeObject<List<Product_Proxy>>(s);
            return product_Proxy;
            //send the proxy and also make a new view.
        }

        private Product_Proxy DeserializeProduct(string s)
        {
            Product_Proxy product_Proxy = JsonConvert.DeserializeObject<Product_Proxy>(s);
            return product_Proxy;
>>>>>>> main
            //send the proxy and also make a new view.
        }

        private void Test()
        {

        }
    }
}

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

namespace Bid501_Client
{
    public delegate void UpdateLoginStatus(State s);
    public class ClientCommControl : WebSocketBehavior
    {
        private WebSocket ws;
        public UpdateLoginStatus updateLoginStatus { get; set; }
        public UpdateListDel updateList { get; set; }
        public ClientCommControl(WebSocket ws)
        {
            this.ws = ws;
        }

        public void SendLoginCredentials(string cred)
        {
            ws.Send(cred);
        }

        private void UpdateLoginStatus(State s)
        {
            //delegate to show if the username and password was valid.
            updateLoginStatus(s);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            string[] split = e.ToString().Split(':');
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
                    List<IProduct> productList = DeserializeProductList(split[1]);
                    updateList(productList);
                    UpdateLoginStatus(Bid501_Shared.State.SUCCESS);
                    break;
                case "DECLINED":
                    UpdateLoginStatus(Bid501_Shared.State.DECLINED);
                    break;
                case "Update":
                    IProduct productUpdate = DeserializeProduct(split[1]);
                    break;
                case "New":
                    IProduct productNew = DeserializeProduct(split[1]);
                    break;
                case "BidEnded":
                    IProduct productEnded = DeserializeProduct(split[1]);
                    break;
            }
        }

        private List<IProduct> DeserializeProductList(string s)
        {
            List<IProduct> product_Proxy = JsonSerializer.Deserialize<List<IProduct>>(s);
            return product_Proxy;
            //send the proxy and also make a new view.
        }

        private IProduct DeserializeProduct(string s)
        {
            IProduct product_Proxy = JsonSerializer.Deserialize<IProduct>(s);
            return product_Proxy;
>>>>>>> main
            //send the proxy and also make a new view.
        }
    }
}

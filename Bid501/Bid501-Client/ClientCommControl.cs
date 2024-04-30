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
            if (split[0] == "login stuff")
            {
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
            //send the proxy and also make a new view.
        }
    }
}

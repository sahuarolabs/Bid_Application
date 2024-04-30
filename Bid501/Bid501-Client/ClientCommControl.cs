using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;
using System.Deployment.Application;
using Bid501_Shared;

namespace Bid501_Client
{
    public delegate void UpdateLoginStatus(State s);
    public class ClientCommControl
    {
        private WebSocket ws;
        public UpdateLoginStatus updateLoginStatus { get; set; }
        public ClientCommControl(WebSocket ws)
        {
            this.ws = ws;
        }

        public void SendLoginCredentials(State s, string cred)
        {
            ws.Send(s.ToString() + cred);
        }

        public void UpdateLoginStatus(State s)
        {
            //delegate to show if the username and password was valid.
            
        }
    }
}

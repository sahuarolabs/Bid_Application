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
    public class ClientCommControl
    {
        private WebSocket ws;
        public ClientCommControl(WebSocket ws)
        {
            this.ws = ws;
        }

        public void UpdateLoginStatus(State s)
        {
            //delegate to show if the username and password was valid.
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Client
{
    public class ClientCommControl
    {
        private WebSocket ws;
        public ClientCommControl(WebSocket ws)
        {
            this.ws = ws;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;

namespace Bid501_Server
{
    // A behavior
    public class Shared : WebSocketBehavior, ILogin
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string msg = e.Data;

            Send("Shared: " + msg);
        }

        public void LogIn(string username, string password)
        {

        }
    }
}

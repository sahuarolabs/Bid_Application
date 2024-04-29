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
    //Server Communication Controller that will Handle communication between Websocket and JSON.Met
    public class ServerCommControl : WebSocketBehavior, ILogin
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string msg = e.Data;

            Send("Shared: " + msg);
        }

        public void LogIn(string username, string password)
        {

        }

        public bool LogInStatus()
        {
            //place holder for now.
            return false;
        }

        public void LogOut(string username)
        {
            throw new NotImplementedException();
        }
    }
}

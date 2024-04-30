using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Server
{
    // A behavior
    public class ServerCommControl : WebSocketBehavior//, ILogin
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string msg = e.Data;

            //Send("Shared: " + msg);
            MessageBox.Show("Shared: " + msg);
        }

        public void LogIn(string username, string password)
        {

        }

       

        public void LogOut(string username)
        {
            throw new NotImplementedException();
        }
    }
}

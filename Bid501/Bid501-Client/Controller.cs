using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501_Client
{
    public class Controller
    {
        private Product_Proxie proxie;
        public LoginDel handleLogin { get; set; } //added
        public UpdateState UpdateLoginState { get; set; }
        public Controller()
        {
        }
        public void Send(string message)
        {

        }

        public List<IProductDB> LogOutHandler(string username)
        {
            return null;
        }

        public void LogInHandler(string cred)
        {
            handleLogin(cred);
        }

        public void UpdateLoginView(State s)
        {
            UpdateLoginState(s);
        }

        public void UpdateProxie(Product_Proxie proxie)
        {
            this.proxie = proxie;
        }
    }
}

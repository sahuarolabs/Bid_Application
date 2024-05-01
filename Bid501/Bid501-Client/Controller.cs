using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate void ViewUpdateListDel(List<Product_Proxy> p);
    public class Controller
    {
        private List<Product_Proxy> productList;
        public LoginDel handleLogin { get; set; } //added
        public LoginRequest loginRequest { get; set; }
        public UpdateState UpdateLoginState { get; set; }
        public ViewUpdateListDel updateList { get; set; }
        public Controller()
        {

        }
        public void UpdateList(List<IProduct> list)
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

        public void LogInStatusHandler(State LoginState)
        {
            UpdateLoginState(LoginState);
        }

        public void UpdateLoginView(State s)
        {
            UpdateLoginState(s);
        }
    }
}

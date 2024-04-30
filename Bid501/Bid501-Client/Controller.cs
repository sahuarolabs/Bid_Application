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
        public LoginDel handleLogin { get; set; } //added
        public LoginRequest loginRequest { get; set; }
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

        public void LogInHandler(State s, string cred)
        {
            handleLogin(s, cred);
        }

        public void LogInStatusHandler(State LoginState)
        {
            UpdateLoginState(LoginState);
        }
    }
}

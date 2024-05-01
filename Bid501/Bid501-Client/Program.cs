using Bid501_Server;
using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate void LoginDel(string cred);
    public delegate void LoginRequest(string username, string password);
    public delegate void UpdateState(Bid501_Shared.State s);
    public delegate void UpdateListDel(List<IProduct> list);
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Websocket testing.
            var ws = new WebSocket("ws://10.130.160.99:8001/shared");//change last 3 digits of IP address by using ipconfig in command prompt to connect to server everytime we swap computers.
            ws.Connect();
            //ws.OnMessage += (sender, e) => Console.WriteLine("Received: " + e.Data);


            //ws.Send("Data from client");

            //Console.ReadKey(true);
            ClientCommControl ccm = new ClientCommControl(ws);
            Controller controller = new Controller();
            ccm.updateList = controller.UpdateList;
            ccm.updateLoginStatus = controller.UpdateLoginView;
            controller.handleLogin = ccm.SendLoginCredentials;
            LoginView loginView = new LoginView();
            ClientView clientView = new ClientView();
            controller.updateList = clientView.UpdateList;
            controller.UpdateLoginState = loginView.DisplayState;
            loginView.handleLogin = controller.LogInHandler;
            Application.Run(loginView);

            //ws.Close();

        }
    }
}

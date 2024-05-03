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
    public delegate void UpdateListDel(List<Product_Proxy> list);
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
            //WebSocket ws = new WebSocket("ws://10.130.160.110:8001");//change last 3 digits of IP address by using ipconfig in command prompt to connect to server everytime we swap computers.
            //ws.Connect();
            //ws.OnMessage += (sender, e) => Console.WriteLine("Received: " + e.Data);


            //ws.Send("Data from client");

            //Console.ReadKey(true);
            Product_ProxyDB ppd = new Product_ProxyDB();
            ClientCommControl ccm = new ClientCommControl();
            ccm.ppd = ppd;
            Controller controller = new Controller();
            controller.product_ProxyDB = ppd;
            controller.logoutUser = ccm.LogoutUser;
            ccm.addProduct = controller.NewProduct;
            ccm.updateProduct = controller.UpdateProduct;
            controller.sendBid = ccm.SendBidItem;
            ccm.updateList = controller.UpdateList;
            ccm.updateLoginStatus = controller.UpdateLoginView;
            controller.handleLogin = ccm.SendLoginCredentials;
            LoginView loginView = new LoginView();
            ClientView clientView = new ClientView(controller.product_ProxyDB);
            clientView.logoutUser = controller.Logout;
            controller.populateListView = clientView.PopulateView;
            controller.listUpdateToServer = ccm.SendBidItem;
            clientView.sendBid = controller.CheckMinBid;
            //controller.updateList = clientView.UpdateList;
            controller.UpdateLoginState = loginView.DisplayState;
            loginView.handleLogin = controller.LogInHandler;
            Application.Run(loginView);

            //ws.Close();

        }
    }
}

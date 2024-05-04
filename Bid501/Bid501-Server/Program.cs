using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using WebSocketSharp.Server;
using WebSocketSharp;
using System.Runtime.CompilerServices;
using System.Net.Sockets;
using System.Net;

namespace Bid501_Server
{
    public delegate void SendServerProduct(Product p);
    public delegate void AddProduct();
    public delegate void AdminOpen();

    public delegate void Success(List<Product> products);
    public delegate void Invalid();
    public delegate void ClientLogin(string username, string password);
    public delegate void Update(Product p);
    public delegate void BidEnded(Product p);

    public delegate void NewProductDel(Product p);
    public delegate void UpdateProductDel(Product p);

    public delegate void displayState(State state); //added
    public delegate void LoginDel(State state, String args); //added
    public delegate void Send(string s); //This is to send messages back an forth.
    public delegate void ResyncDel();
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            AccountModel am = new AccountModel();
            ProductModel pm = new ProductModel();
            Controller controller = new Controller(pm, am);
        
            LoginView view = new LoginView(controller.AdminOpen, am);
            //WebSocketServer wss = new WebSocketServer("ws://10.7.172.110:8001");
            //wss.ReuseAddress = true;
            //wss.Start();
            
            //ServerCommControl sc = new ServerCommControl();
            //sc.SetInit(controller.ClientLogin, controller.UpdateProducts, pm, wss);
            //wss.AddWebSocketService<ServerCommControl>("/shared", s => s.SetInit(controller.ClientLogin, controller.UpdateProducts, pm, wss));
            //sc.SetInit(controller.ClientLogin, controller.UpdateProducts, pm, wss);
            //wss.Start();

            //AdminView adminView = new AdminView(controller.BidEnded, controller.AddProduct, pm, am);
            AddProductView addProduct = new AddProductView(controller.SendServerProduct , pm);
       //     controller.displayState = view.DisplayState; //added
            view.handleLogin = controller.handleEvents; //added
            

            int port = 8001;
            IPAddress localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("192.168.86.21", port);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address;
            }
            WebSocketServer wssv = new WebSocketServer(localIP, port);
            AdminView adminView = new AdminView(controller.BidEnded, controller.AddProduct, pm, am);
            wssv.AddWebSocketService("/shared", () =>
            {
                ServerCommControl scc = new ServerCommControl();
                scc.SetInit(controller.ClientLogin, controller.UpdateProducts, pm, wssv);
                controller.InitializeDelegates(scc.SendProductList, scc.InvalidLogin, scc.UpdateProduct, addProduct.AddProduct, adminView.Resync, adminView.AdminOpen, scc.BidEnded, scc.SendServerProduct);
                return scc;
            });
            wssv.Start();

            //controller.InitializeDelegates(sc.SendProductList, sc.InvalidLogin, sc.UpdateProduct, addProduct.AddProduct, adminView.Resync, adminView.AdminOpen, sc.BidEnded, sc.SendServerProduct);

            Application.Run(view);
            //wssv.Stop();
            //controller.Close();

            

        }
    }
}

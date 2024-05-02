using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using WebSocketSharp.Server;
using WebSocketSharp;
using System.Runtime.CompilerServices;

namespace Bid501_Server
{
    public delegate void SendServerProduct(Product p);
    public delegate void AddProduct();
    public delegate void AdminOpen();


    public delegate bool ClientLogin(string username, string password);
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
            WebSocketServer wss = new WebSocketServer(8001);

            wss.AddWebSocketService<ServerCommControl>("/shared");

            wss.Start();
            AccountModel am = new AccountModel();
            ProductModel pm = new ProductModel();
            Controller controller = new Controller(pm, am);
        
            LoginView view = new LoginView(controller.AdminOpen, am);

            ServerCommControl sc = new ServerCommControl(controller.ClientLogin,controller.UpdateProducts,pm, wss);

            AdminView adminView = new AdminView(controller.BidEnded, controller.AddProduct, pm);
            AddProductView addProduct = new AddProductView(controller.SendServerProduct , pm);
       //     controller.displayState = view.DisplayState; //added
            view.handleLogin = controller.handleEvents; //added
            controller.InitializeDelegates(sc.UpdateProduct,addProduct.AddProduct, adminView.Resync, adminView.AdminOpen, sc.BidEnded, sc.SendServerProduct);
            Application.Run(view);
            
            controller.Close();

            

        }
    }
}

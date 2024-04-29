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
            var wss = new WebSocketServer(8001);

            wss.AddWebSocketService<ServerCommControl>("/shared");

            wss.Start();
            LoginView view = new LoginView();

            Controller controller = new Controller();
            //view.SetController(controller);

            controller.displayState = view.DisplayState; //added
            view.handleLogin = controller.handleEvents; //added

            Application.Run(view);
            
            controller.Close();

            

        }
    }
    public delegate void displayState(State state); //added
    public delegate void LoginDel(State state, String args); //added
    public delegate void Send(string s); //This is to send messages back an forth.
}

using Bid501_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate void LoginDel(Bid501_Shared.State s, string cred);
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
            var ws = new WebSocket("ws://127.0.0.1:8001/shared");
            ws.Connect();
            //ws.OnMessage += (sender, e) => Console.WriteLine("Received: " + e.Data);


            //ws.Send("Data from client");

            //Console.ReadKey(true);
            ClientCommControl ccm = new ClientCommControl(ws);
            Controller controller = new Controller();
            Application.Run(new LoginView());
            //ws.Close();
            
        }
    }
}

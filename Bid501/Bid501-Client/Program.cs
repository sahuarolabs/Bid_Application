using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
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

            
            ws.Send("Data from client");

            //Console.ReadKey(true);
            Application.Run(new Form1(ws));
            ws.Close();
            
        }
    }
}

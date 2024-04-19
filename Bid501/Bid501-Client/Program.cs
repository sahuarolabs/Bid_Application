using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Websocket testing.
            var ws = new WebSocket("ws://localhost:9006/Test");
            ws.OnMessage += (sender, e) => Console.WriteLine("Received: " + e.Data);

            ws.Connect();
            ws.Send("Data from client");

            Console.ReadKey(true);
            ws.Close();
        }
    }
}

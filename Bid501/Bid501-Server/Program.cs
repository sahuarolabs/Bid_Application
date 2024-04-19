using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using WebSocketSharp.Server;
using WebSocketSharp;

namespace Bid501_Server
{
    public class TestService : WebSocketServer
    {
        // Click Events that should be happening.
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Recieved something from the client: " + e.Data);

            Send("Data from server");
        }

        protected override void OnError(WebSocketSharp.ErrorEventArgs e)
        {
            // do nothing
        }
    }

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

            Form1 view = new Form1();

            Controller controller = new Controller();
            //view.SetController(controller);

            controller.ds = view.DisplayState; //added
            view.he = controller.handleEvents; //added

            Application.Run(view);
            controller.Close();

            // Added some websocket stuff.
            var ws = new WebSocketServer("ws://localhost:9006");

            ws.AddWebSocketService<TestService>("/Test");
            ws.Start();
            Console.ReadKey(true);
            ws.Stop();

        }
    }
    public delegate void displayState(State state); //added
    public delegate void handleEvents(State state, String args); //added
    public delegate void Send(string s); //This is to send messages back an forth.
}

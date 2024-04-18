using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Bid501_Server
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

            Form1 view = new Form1();

            Controller controller = new Controller();
            //view.SetController(controller);

            controller.ds = view.DisplayState; //added
            view.he = controller.handleEvents; //added

            Application.Run(view);
            controller.Close();

        }
    }
    public delegate void displayState(State state); //added
    public delegate void handleEvents(State state, String args); //added
}

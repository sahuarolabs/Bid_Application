using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Server;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    public partial class ClientLogIn : Form
    {
        private WebSocket ws;
        public ClientLogIn(WebSocket ws)
        {
            this.ws = ws;
            InitializeComponent();
        }

        private void UxLoginBtn_Click(object sender, EventArgs e)
        {
            // send message to the server.
            ws.Send("Data from client");
        }
    }
}

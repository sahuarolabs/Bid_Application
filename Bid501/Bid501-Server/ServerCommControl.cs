using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Windows.Forms;
using Bid501_Shared;
using System.Text.Json;

namespace Bid501_Server
{
    // A behavior
    public class ServerCommControl : WebSocketBehavior//, ILogin
    {
        /// <summary>
        /// The private websocket used to send information.
        /// </summary>
        private WebSocket ws;

        public ServerCommControl(WebSocket ws)
        {
            this.ws = ws;
        }
        /// <summary>
        /// Method for when the server receives messages from the client using JSON.
        /// </summary>
        /// <param name="e">The message that is sent through the websocket using JSON.</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            string[] msgs = e.ToString().Split(':');

            if (msgs.Length == 3)
            {
                string username = msgs[1];
                string password = msgs[2];
                //send the username and passwords to the controller to handle
            }
            else
            {
                string msg = msgs[1];
                Product product = JsonSerializer.Deserialize<Product>(msg);
                //send product to the controller to be handled.
            }
            //deserialize the data to the appropriate object or string.
            //then send it to the controller for validation after deserialize.


            //Send("Shared: " + msg);
            //MessageBox.Show("Shared: " + msg);
        }
        /// <summary>
        /// Method to use when the server wants to send over the list of products.
        /// </summary>
        /// <param name="cred">The list sent to the client using JSON.</param>
        public void SendProductList(List<Product> products)
        {
            //send data in form of what the object is then append it onto the message.
            //Serialize objects before sending too.
            //string msg = "Proxy:" + msg;
        }
        /// <summary>
        /// Method to send a product to the client when a product needs to be updated.
        /// </summary>
        /// <param name="product">The product that needs to be updated.</param>
        public void SendProduct(Product product)
        {

        }
        /// <summary>
        /// Method to send a message to all users that a bid has ended.
        /// </summary>
        /// <param name="product">The product that the bid ended on.</param>
        public void BidEnded(Product product)
        {

        }

    }
}
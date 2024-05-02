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
using System.Net.Configuration;

namespace Bid501_Server
{  
    // A behavior
    public class ServerCommControl : WebSocketBehavior//, ILogin
    {
        /// <summary>
        /// The private websocket used to send information.
        /// </summary>
        private WebSocket ws;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ServerCommControl() { }

        public ServerCommControl(WebSocket ws)
        {
            this.ws = ws;
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            Console.WriteLine("NEW CLIENT CONNECTED");
        }

        /// <summary>
        /// Method for when the server receives messages from the client using JSON.
        /// </summary>
        /// <param name="e">The message that is sent through the websocket using JSON.</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            string[] msgs = e.Data.ToString().Split(':');

            if (msgs.Length == 3)
            {
                string username = msgs[1];
                string password = msgs[2];
                //send the username and passwords to the controller to handle
                //NEED TO WORK ON DELEGATES
            }
            else
            {
                string msg = msgs[1];
                Product product = JsonSerializer.Deserialize<Product>(msg);
                //send product to controller to validate bid and then send updates afterwards.
                //NEED TO WORK ON DELEGATES
            }
        }
        /// <summary>
        /// Method to use when the server wants to send over the list of products.
        /// </summary>
        /// <param name="cred">The list sent to the client using JSON.</param>
        public void SendProductList(List<Product> products)
        {
            string msg = JsonSerializer.Serialize<List<Product>>(products);
            msg = "Success:" + msg;
            ws.Send(msg);
        }
        /// <summary>
        /// Method to use when the user has invalid login information.
        /// </summary>
        public void InvalidLogin()
        {
            string msg = "DECLINED";
            ws.Send(msg);
        }
        /// <summary>
        /// Method to send a product to the client when a product needs to be updated.
        /// </summary>
        /// <param name="product">The product that needs to be updated.</param>
        public void UpdateProduct(Product product)
        {
           string msg = JsonSerializer.Serialize<Product>(product);
            msg = "Update:" + msg;
            ws.Send(msg);
        }
        /// <summary>
        /// Method to notify all users that a new product has been added to the auction.
        /// </summary>
        /// <param name="product">The new product</param>
        public void SendServerProduct(Product product)
        {
            string msg = JsonSerializer.Serialize<Product>(product);
            msg = "New:" + msg;
            ws.Send(msg);
        }
       
        /// <summary>S
        /// Method to send a message to all users that a bid has ended.
        /// </summary>
        /// <param name="product">The product that the bid ended on.</param>
        public void BidEnded(Product product)
        {
            string msg = JsonSerializer.Serialize<Product>(product);
            msg = "BidEnded:" + msg;
            ws.Send(msg);
        }
    }
}
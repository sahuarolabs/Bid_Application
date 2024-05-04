using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Windows.Forms;
using Bid501_Shared;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Net.Configuration;

namespace Bid501_Server
{  
    // A behavior
    public class ServerCommControl : WebSocketBehavior//, ILogin
    {
        /// <summary>
        /// The private websocket used to send information.
        /// </summary>
        private WebSocketServer ws;

        private List<string> listClients = new List<string>();
        private List<string> allActiveSockets = new List<string>();

        /// <summary>
        /// Empty constructor
        /// </summary>
        private HighestBidder bidder;
        private AccountStarted acID;
        private ProductModel products;
        private ClientLogin clientLogin;
        private Update update;
        private List<Product> modProd;

        
        //public ServerCommControl(ClientLogin clientlog, Update u, ProductModel p, WebSocketServer ws)
        //{
        //    this.clientLogin = clientlog;
        //    products = p;
        //    update = u;
        //    this.ws = ws;
        //}

        public void SetInit(HighestBidder b,AccountStarted a,ClientLogin clientlog, Update u, ProductModel p, WebSocketServer ws)
        {
            bidder = b;
            acID = a;
            this.clientLogin = clientlog;
            products = p;
            update = u;
            this.ws = ws;
            modProd = p.products;
        }

        /// <summary>
        /// Method for when the server receives messages from the client using JSON.
        /// </summary>
        /// <param name="e">The message that is sent through the websocket using JSON.</param>
        protected override void OnMessage(MessageEventArgs e)
        {
            string[] msgs = e.Data.ToString().Split('|');
            string[] msgs2 = e.Data.ToString().Split(':');
            if (msgs2.Length == 3)
            {
                string username = msgs2[1];
                string password = msgs2[2];
                //send the username and passwords to the controller to handle
                //NEED TO WORK ON DELEGATES
              clientLogin(username, password); 
      
            }
            else if(msgs[0] == "Connection")
            {
                string user = msgs[1];
                allActiveSockets.Add(user);
                acID(allActiveSockets);
            }
            else
            {
                string msg = msgs[0];
                string highestBidder = msgs[1];
                Product product = JsonConvert.DeserializeObject<Product>(msg);
                //Product product = JsonSerializer.Deserialize<Product>(msg);
                //delegate to send the highest bidder.
                bidder(highestBidder);
                update(product);
                //send product to controller to validate bid and then send updates afterwards.
                //NEED TO WORK ON DELEGATES
            }
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            listClients.Add(ID);
        }

        /// <summary>
        /// Method to use when the server wants to send over the list of products.
        /// </summary>
        /// <param name="cred">The list sent to the client using JSON.</param>
        public void SendProductList(List<Product> prods)
        {
            prods = products.Sync();
            string msg = JsonConvert.SerializeObject(prods);
            //string msg = JsonSerializer.Serialize<List<Product>>(modProd);
            msg = "Success|" + msg;
            Send(msg);
            
        }
        /// <summary>
        /// Method to use when the user has invalid login information.
        /// </summary>
        public void InvalidLogin()
        {
            string msg = "DECLINED|";
            Send(msg);
        }
        /// <summary>
        /// Method to send a product to the client when a product needs to be updated.
        /// </summary>
        /// <param name="product">The product that needs to be updated.</param>
        public void UpdateProduct(Product product)
        {
            string msg = JsonConvert.SerializeObject(product);
           //string msg = JsonSerializer.Serialize<Product>(product);
            msg = "Update|" + msg;
            Send(msg);
        }
        /// <summary>
        /// Method to notify all users that a new product has been added to the auction.
        /// </summary>
        /// <param name="product">The new product</param>
        public void SendServerProduct(Product product)
        {
            string msg = JsonConvert.SerializeObject(product);
            //string msg = JsonSerializer.Serialize<Product>(product);
            msg = "New|" + msg;
            Send(msg);
        }
       
        /// <summary>S
        /// Method to send a message to all users that a bid has ended.
        /// </summary>
        /// <param name="product">The product that the bid ended on.</param>
        public void BidEnded(Product product)
        {
            string msg = JsonConvert.SerializeObject(product);
            //string msg = JsonSerializer.Serialize<Product>(product);
            msg = "BidEnded|" + msg;
            try
            {
                Send(msg);
            }
            catch
            {
                MessageBox.Show("No one connected");
            }
            
        }
    }
}
using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate void ViewUpdateListDel();
    public delegate void SendBid(Product_Proxy p);
    public delegate void ListUpdate();
    public delegate void ListUpdateToServer(IProduct product);
    public delegate void PopulateListView();
    public class Controller
    {
        private List<IProduct> productList;
        public LoginDel handleLogin { get; set; } //added
        public LoginRequest loginRequest { get; set; }
        public UpdateState UpdateLoginState { get; set; }
        //public ViewUpdateListDel updateList { get; set; }
        public SendBid sendBid { get; set; }
        public ListUpdate listUpdate { get; set; }
        public ListUpdateToServer listUpdateToServer { get; set; }
        public PopulateListView populateListView { get; set; }
        public void UpdateList(List<IProduct> list)
        {
            productList = list;
            populateListView();
        }
        public void Send(string message)
        {

        }

        public List<IProductDB> LogOutHandler(string username)
        {
            return null;
        }

        public void LogInHandler(string cred)
        {
            handleLogin(cred);
        }

        public void LogInStatusHandler(State LoginState)
        {
            UpdateLoginState(LoginState);
        }

        public void UpdateLoginView(State s)
        {
            UpdateLoginState(s);
        }

        public void CheckMinBid(IProduct product, double bid)
        {
            int i = 0;
            foreach (Product_Proxy p in productList)
            {
                if (p.ID == product.ID && bid > product.bidHistory[product.bidHistory.Count - 1]) productList[i].bidHistory.Add(bid);
                sendBid(p);
                i++;
            }
        }

        public void UpdateProduct(IProduct product)
        {
            int ind = 0;
            foreach(IProduct p in productList)
            {
                if (p.ID == product.ID)
                {
                    productList[ind] = product;
                    ProductListUpdated();
                }
                ind++;
            }
        }

        private void ProductListUpdated()
        {
            listUpdate();
        }

        private void ProductListUpdateToServer(IProduct product)
        {
            listUpdateToServer(product);
        }

        /// <summary>
        /// Adds/Sends that a new product has been added to the list to the view.
        /// </summary>
        /// <param name="product"></param>
        public void NewProduct(IProduct product)
        {
            productList.Add(product);
            ProductListUpdated();
        }
    }
}

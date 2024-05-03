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
    public delegate void PopulateListView(int ind);
    public delegate void LogoutUserDel(string cred);
    public class Controller
    {
        private List<IProduct> productList;
        public Product_ProxyDB product_ProxyDB { get; set; }
        public LoginDel handleLogin { get; set; } //added
        public LoginRequest loginRequest { get; set; }
        //public ViewUpdateListDel updateList { get; set; }
        public SendBid sendBid { get; set; }
        public ListUpdate listUpdate { get; set; }
        public ListUpdateToServer listUpdateToServer { get; set; }
        public PopulateListView populateListView { get; set; }
        public LogoutUserDel logoutUser { get; set; }
        public TurnClientViewOn turnClientViewOn { get; set; }
        public UpdateLoginStatus updateLogin { get; set; }
        private string cred;
        public void UpdateList(List<Product_Proxy> list)
        {
            product_ProxyDB.PL = list;
            populateListView(0);
            updateLogin(State.SUCCESS);
        }

        public List<IProductDB> LogOutHandler(string username)
        {
            return null;
        }

        public void LogInHandler(string cred)
        {
            this.cred = cred;
            handleLogin(cred);
        }

        public void CheckMinBid(Product_Proxy product, double bid)
        {
            int i = 0;
            //foreach (Product_Proxy p in product_ProxyDB.ProductList)
            //{
            //    if (p.ID == product.ID && bid > product.bidHistory[product.bidHistory.Count - 1]) productList[i].bidHistory.Add(bid);
            //    sendBid(p);
            //    i++;
            //}
            if (product.Price < bid)
            {
                sendBid(product);
            }
        }

        public void UpdateProduct(IProduct product)
        {
            int ind = 0;
            foreach(Product_Proxy p in product_ProxyDB.ProductList)
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
            product_ProxyDB.ProductList.Add(product);
            ProductListUpdated();
        }

        public void Logout()
        {
            logoutUser(cred);
        }

        public void TurnViewOnClient()
        {
            turnClientViewOn();
        }
    }
}

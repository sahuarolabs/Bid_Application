using Bid501_Server;
using System.Net.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;
using System.Windows.Forms;


//TBD remeber which user has the highest bid for when we end the bid
//have to send out message alerting users who won the bid.
namespace Bid501_Server
{ 
    public enum State
    {
        NOTINIT = -1,
        START = 0,
        GOTUSERNAME,
        GOTPASSWORD,
        SUCCESS,
        DECLINED,
        EXIT
    }

    public class Controller
    {
       
        private AddProduct addProductViewOpen;
        private SendServerProduct ssp;
        private AdminOpen adOpen;

        private Success goodLogin;
        private Invalid badLogin;
        private UpdateProductDel updateProduct;

        private ProductModel product;
        private AccountModel account;

        private ResyncDel resyncDel;
        private BidEnded bidChanged;
        List<Account> activeClients;
        List<Account> accounts;
        public displayState displayState { get; set; } //added

        WebSocket ws;


        public Controller(ProductModel p, AccountModel am)
        {
            this.account = am;
            this.product = p;
            ws = new WebSocket("ws://127.0.0.1:8001/shared");
            ws.Connect();
            activeClients = am.AccountSync();
        }

        public void Close()
        {
            ws.Close();
        }
        public void AdminOpen()
        {
            adOpen();
        }

        public void handleEvents(State state, String args)
        {
            switch (state)
            {
                case State.START:

                    displayState(State.START); //changed
                    break;
                case State.GOTUSERNAME:
                    displayState(State.GOTUSERNAME); //changed
                    break;
                case State.GOTPASSWORD:
                    displayState(State.GOTPASSWORD); //changed
                    ValidateCredentials(args);

                    break;
                default:
                    break;
            }
        }

        //method to validate login
        public void ClientLogin(string username, string password)
        {
            accounts = account.AccountSync();
            foreach (Account accou in accounts)
            {
                if (username == accou.Username && password == accou.Password)
                {
                    if (!accou.IsAdmin)
                    {
                        goodLogin(product.SyncHardcoded());
                        break;
                    }
                }
            }
            //badLogin();
        }



        public void InitializeDelegates(Success su, Invalid i, UpdateProductDel up,AddProduct add, ResyncDel resync, AdminOpen ao, BidEnded b, SendServerProduct s)
        {
            goodLogin = su;
            badLogin = i;
            updateProduct = up;
            ssp = s;
            bidChanged = b;
            adOpen = ao;
            addProductViewOpen = add;
            resyncDel = resync;
        }

        private void ValidateCredentials(String cred)
        {
            ws.Send(cred);
        }

        public void UpdateProducts(Product p)
        {
            foreach(Product prod in product.SyncHardcoded())
            {
                if(prod.ID == p.ID)
                {
                    if(p.Price > prod.Price)
                    {
                        prod.Price = p.Price;
                        updateProduct(prod);
                    }
                }
            }
        }


        public void AddProduct()
        {
            addProductViewOpen();
            resyncDel();
        }

        public void SendServerProduct(Product p)
        { 
            ssp(p);

        }

        public void BidEnded(Product p)
        { 
            bidChanged(p);
        }
    }
}

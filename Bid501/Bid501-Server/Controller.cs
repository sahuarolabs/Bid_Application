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
        private ClientLogin cl;
        private AddProduct addProductViewOpen;
        private SendServerProduct ssp;
        private AdminOpen adOpen;
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
            ws = new WebSocket("ws://127.0.0.1:8001/login");
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
               //     validateCredentials(args);
                    break;
                default:
                    break;
            }
        }

        //method to validate login
        public bool ClientLogin(string username, string password)
        {
            foreach (Account account in accounts)
            {
                if (username == account.Username && password == account.Password)
                {
                    if (!account.IsAdmin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public void InitializeDelegates(AddProduct add, ResyncDel resync, AdminOpen ao, BidEnded b, SendServerProduct s, ClientLogin cllog)
        {
            cl = cllog; 
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

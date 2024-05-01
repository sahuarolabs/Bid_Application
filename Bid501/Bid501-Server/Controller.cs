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
        private AddProduct addProductViewOpen;
        private AdminOpen adOpen;
        private ProductModel product;
        private AccountModel account;
        private ResyncDel resyncDel;
        private BidEnded bidChanged;
        public displayState displayState { get; set; } //added

        WebSocket ws;
     

        public Controller(ProductModel p, AccountModel am)
        {
            this.account = am;
            this.product = p;
            ws = new WebSocket("ws://127.0.0.1:8001/login");
            ws.OnMessage += OnMessage;
            ws.Connect();
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
                    validateCredentials(args);
                    break;
                default:
                    break;
            }
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            MessageBox.Show("Recieved");
            if (e.Data.Equals("VALID"))
            {
                displayState(State.SUCCESS); //changed
            }
            else
            {
                displayState(State.DECLINED); //changed
            }

        }

        public void InitializeDelegates(AddProduct add, ResyncDel resync, AdminOpen ao, BidEnded b)
        {
            bidChanged = b; 
            adOpen = ao;    
            addProductViewOpen = add;
            resyncDel = resync;
        }

        private void validateCredentials(String cred)
        {
            ws.Send(cred);
        }

        public void AddProduct()
        {
            addProductViewOpen();
            resyncDel();
        }

        public void BidEnded(Product p)
        {
            bidChanged(p);
        }
    }
}

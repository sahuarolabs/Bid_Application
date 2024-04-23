using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501_Shared
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://127.0.0.1:8001/shared"))
            {
                ws.OnMessage += (sender, e) => Console.WriteLine(e.Data);

                ws.Connect();
            }
        }
    }
}

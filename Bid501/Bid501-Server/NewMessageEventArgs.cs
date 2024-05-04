using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class NewMessageEventArgs : EventArgs
    {
        public string LogData { get; set; }
        public string Username { get; set; }
    }
}

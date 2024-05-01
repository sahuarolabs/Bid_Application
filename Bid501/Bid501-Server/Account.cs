using Bid501_Shared;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsAdmin = false;
        
        public Account(string username, string password, bool flag) 
        { 
            Username = username;
            Password = password;
            IsAdmin = flag;
        }

      
    }
}

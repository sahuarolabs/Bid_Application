using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Account
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool LoginStatus { get; set; }       

        public AccountType Type { get; private set; }

        public Account(AccountType type)
        {
            Type = type;
        }

        public AccountType ValidateAccountType(string username, string password)
        {
            if(username == UserName && password == Password)
            {
                return Type;
            }
        }
    }
}

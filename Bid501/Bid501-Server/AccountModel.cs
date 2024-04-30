using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bid501_Server
{
    public class AccountModel
    {
        public List<Account> accounts;

        public AccountModel() 
        {
            accounts = new List<Account>();
            Account a = new Account("ella", "carlson", true);
            Account b = new Account("dylan", "rosquist", false);
            Account c = new Account("sam", "allred", false);
            Account d = new Account("caleb", "chan", true);
            Account e = new Account("jorge", "v", false);
            accounts.Add(a);
            accounts.Add(b);
            accounts.Add(c);
            accounts.Add(d);
            accounts.Add(e);
            MakeAccounts();
        }


        public void MakeAccounts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Account a in accounts)
            {
                string writeJson = JsonConvert.SerializeObject(a);
                stringBuilder.Append(writeJson + "\n");
            }
            File.WriteAllText("..\\..\\accounts.txt", stringBuilder.ToString());
        }
    }
}

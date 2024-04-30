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
            accounts = LoadAccounts();
        }

        public List<Account> LoadAccounts()
        {
            List<Account> templist = new List<Account>();
            if (File.Exists("..\\..\\accounts.txt"))
            {
                StreamReader streamReader = new StreamReader("..\\..\\accounts.txt");
                while (!streamReader.EndOfStream)
                {
                    string acc = streamReader.ReadLine();
                    Account a = JsonConvert.DeserializeObject<Account>(acc);
                    templist.Add(a);
                }
                streamReader.Close();
            }
            return templist;
        }
    }
}

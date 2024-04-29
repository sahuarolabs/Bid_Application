using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface ILogin
    {
        public void LogIn(string username, string password);

        public void LogOut(string username);

        public Boolean LogInStatus();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface ILogin
    {
        void LogIn(string username, string password);

        void LogOut(string username);

        bool LogInStatus();
    }
}

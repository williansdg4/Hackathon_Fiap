using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Interfaces
{
    public interface IAccountManager
    {
        string Authenticate(string userName, string email, string password);
        void CreateUser(string userName, string email, string password, string role);
    }
}

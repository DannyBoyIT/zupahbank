using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Models;

namespace BusinessLib.Interfaces
{
    public interface IAccountManagement
    {
        void Create(int accountId, int customerId, decimal balance);
        void Delete(int accountId);
       
        List<Account> AllAccounts();
    }
}

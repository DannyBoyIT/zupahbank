using System.Collections.Generic;
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

using System.Collections.Generic;
using BusinessLib.Models;

namespace BusinessLib.Interfaces
{
    public interface IAccountManagement
    {
        void Create(int customerId);
        void Delete(int accountId);
       
        List<Account> AllAccounts();
    }
}

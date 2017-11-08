using System.Collections.Generic;
using BusinessLib.Models;

namespace BusinessLib.Interfaces
{
    public interface IAccountManagement
    {
        bool Create(int customerId);
        bool Delete(int accountId);
       
        List<Account> AllAccounts();
    }
}

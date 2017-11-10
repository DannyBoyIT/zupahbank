using System.Collections.Generic;
using BusinessLib.Models;

namespace BusinessLib.Interfaces
{
    public interface IAccountManagement
    {
        bool Create(int customerId);
        bool Delete(int accountId);
       
        List<Account> AllAccounts();

        bool Withdraw(int accountId, decimal amount);
        bool Deposit(int accountId, decimal amount);
    }
}

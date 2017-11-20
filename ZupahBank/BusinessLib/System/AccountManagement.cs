using System.Collections.Generic;
using BusinessLib.Interfaces;
using BusinessLib.Models;

namespace BusinessLib.System
{
    public class AccountManagement : IAccountManagement
    {
        private readonly IRepository _repo;
        public AccountManagement(IRepository repo)
        {
            _repo = repo;
        }
        
        public int GetNumberOfAccounts()
        {
            return _repo.NumberOfAccounts();
        }

        public List<Account> AllAccounts()
        {
            return _repo.GetAllAccounts();
        }
         
        public bool Create(int customerId)
        {
            return _repo.CreateAccount(customerId);
        }
         
        public bool Delete(int accountId)
        {
            var allAccounts = _repo.GetAllAccounts();
            var acc = allAccounts.Find(x => x.AccountId == accountId);
            if (acc.Balance == 0)
            {
                return _repo.DeleteAccount(accountId);
            }
            return false;
        }

        public bool Withdraw(int accountId, decimal amount)
        {
            if (amount < 1)
            {
                return false;
            }

            var balance = _repo.GetBalance(accountId);

            decimal newBalance;

            if(balance > 0)
            {
                newBalance = balance - amount;
            }

            else
            {
                return false;
            }           
            
            if(newBalance < 0)
            {
                return false;
            }

            _repo.UpdateBalance(accountId, newBalance);

            return true;
        }

        public bool Deposit(int accountId, decimal amount)
        {
            if (amount < 0)
            {
                return false;
            }

            var balance = _repo.GetBalance(accountId);

            decimal newBalance = balance + amount;

            _repo.UpdateBalance(accountId, newBalance);

            return true;
        }

        public decimal TotalBalance()
        {
            return _repo.TotalBalance();
        }
    }
}

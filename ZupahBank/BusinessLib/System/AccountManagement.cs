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
            return _repo.DeleteAccount(accountId);
        }
    }
}

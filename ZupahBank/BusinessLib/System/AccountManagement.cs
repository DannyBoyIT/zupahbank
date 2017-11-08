using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Interfaces;
using BusinessLib.Models;
using BusinessLib.Repositories;

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

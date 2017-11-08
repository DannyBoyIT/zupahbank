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
            throw new NotImplementedException();
        }

        public void Create( int customerId)
        {
            _repo.CreateAccount( customerId);
        }

        public void Delete(int accountId)
        {
            _repo.DeleteAccount(accountId);
        }
    }
}

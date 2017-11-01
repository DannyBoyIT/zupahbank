using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Interfaces;
using BusinessLib.Models;

namespace BusinessLib.Repositories
{
    public class FileRepository : IRepository
    {
        public void CreateCustomer(string customerName, string legalId, string address, string zipCode, string city, string region,
            string country, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(decimal balance, int customerId)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(decimal amount, Account toAccount, Account fromAccount)
        {
            throw new NotImplementedException();
        }
    }
}

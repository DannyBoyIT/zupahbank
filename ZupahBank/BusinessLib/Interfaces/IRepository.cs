using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Models;

namespace BusinessLib.Interfaces
{
    public interface IRepository
    {
        void CreateCustomer(
            string customerName, 
            string legalId, 
            string address, 
            string zipCode, 
            string city, 
            string region, 
            string country, 
            string phoneNumber);

        void CreateAccount(decimal balance, int customerId);

        void CreateTransaction(decimal amount, Account toAccount, Account fromAccount);
    }
}

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
        int NumberOfAccounts();
        int NumberOfCustomers();
        decimal TotalBalance();

        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomer(string searchTerm);
        Customer GetCustomer(int customerId);
        bool CreateCustomer(string customerName,
            string legalId,
            string address,
            string zipCode,
            string city,
            string region = "",
            string country = "",
            string phoneNumber = "");
        bool DeleteCustomer(int customerId);
        List<Account> GetAllAccounts();
        bool CreateAccount(int customerId);
        bool DeleteAccount(int accountId);
        decimal GetBalance(int accountId);
        bool UpdateBalance(int accountId, decimal newBalance);
        bool UpdateBalance(int fromAccountId, int toAccountId, decimal fromAccountNewBalance, decimal toAccountNewBalance);
    }
}

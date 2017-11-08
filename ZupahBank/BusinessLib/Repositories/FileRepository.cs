using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLib.Interfaces;
using BusinessLib.Models;
using BusinessLib.Services;
using System;

namespace BusinessLib.Repositories
{
    public sealed class FileRepository : IRepository
    {

        private static readonly FileRepository _instance = new FileRepository();

        private FileRepository() { }

        public static FileRepository Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public int NumberOfAccounts => Accounts.Count;
        public int NumberOfCustomers => Customers.Count;
        public decimal TotalBalance => Accounts.Sum(account => account.Balance);
        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomer(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            return Customers.Where(x => 
                x.CustomerName.ToLower().Contains(searchTerm) || x.City.ToLower().Contains(searchTerm))
                .ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void CreateCustomer(int customerId, string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "")
        {
            Customers.Add(new Customer {
                Address = address,
                City = city,
                Country = country,
                CustomerId = customerId,
                CustomerName = customerName,
                LegalId = legalId,
                PhoneNumber = phoneNumber,
                Region = region,
                ZipCode = zipCode
            });
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(int accountId, int customerId, decimal balance)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(int accountId)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance(int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateBalance(int accountId, decimal newBalance)
        {
            throw new NotImplementedException();
        }

        public void UpdateBalance(int fromAccountId, int toAccountId, decimal fromAccountNewBalance, decimal toAccountNewBalance)
        {
            throw new NotImplementedException();
        }
    }
}

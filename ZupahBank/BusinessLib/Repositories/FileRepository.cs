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

        private static volatile FileRepository _instance;
        private static readonly object SyncRoot = new object();

        private FileRepository() { }

        public static FileRepository Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new FileRepository();
                }
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

        public void CreateCustomer(string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "")
        {
            var customerIds = Customers.Select(x => x.CustomerId);
            var newCustomerNo = customerIds == null ? 1: customerIds.Max() + 1; 

            Customers.Add(new Customer
            {
                Address = address,
                City = city,
                Country = country,
                CustomerId = newCustomerNo,
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

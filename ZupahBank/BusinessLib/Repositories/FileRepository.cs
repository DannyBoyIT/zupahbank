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

        private List<Account> Accounts { get; set; } = new List<Account>();
        private List<Customer> Customers { get; set; } = new List<Customer>();

        public int NumberOfAccounts() => Accounts.Count;
        public int NumberOfCustomers() => Customers.Count;
        public decimal TotalBalance() => Accounts.Sum(account => account.Balance);

        public List<Customer> GetAllCustomers() => Customers;

        public List<Customer> SearchCustomer(string searchTerm) => Customers.Where(x=>x.CustomerName.Contains(searchTerm) || x.City.Contains(searchTerm)).ToList();
        
        public Customer GetCustomer(int customerId) => Customers.FirstOrDefault(x => x.CustomerId == customerId);

        public void CreateCustomer(int customerId, string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "")
        {
            var customer = new Customer
            {
                CustomerId = customerId,
                Address = address,
                PhoneNumber = phoneNumber,
                City = city,
                Region = region,
                ZipCode = zipCode,
                LegalId = legalId,
                CustomerName = customerName,
                Country = country
            };
            Customers.Add(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                var customer = Customers.FirstOrDefault(x => x.CustomerId == customerId);
                Customers.Remove(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Account> GetAllAccounts() => Accounts;

        public void CreateAccount(int accountId, int customerId, decimal balance)
        {
            try
            {
                var account = new Account
                {
                    CustomerId = customerId,
                    Balance = balance,
                    AccountId = accountId
                };
                Accounts.Add(account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteAccount(int accountId)
        {
            try
            {
                var account = Accounts.FirstOrDefault(x => x.AccountId == accountId);
                Accounts.Remove(account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public decimal GetBalance(int accountId)
        {
            try
            {
                var account = Accounts.First(x => x.AccountId == accountId);
                return account.Balance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateBalance(int accountId, decimal newBalance)
        {
            try
            {
                var account = Accounts.First(x => x.AccountId == accountId);
                account.Balance = newBalance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void UpdateBalance(int fromAccountId, int toAccountId, decimal fromAccountNewBalance, decimal toAccountNewBalance)
        {
            try
            {
                Accounts.First(x => x.AccountId == toAccountId).Balance = toAccountNewBalance;
                Accounts.First(x => x.AccountId == fromAccountId).Balance = toAccountNewBalance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}

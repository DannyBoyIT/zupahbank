﻿using System.Collections.Generic;
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

        public List<Customer> SearchCustomer(string searchTerm) => Customers.Where(x => x.CustomerName.Contains(searchTerm) || x.City.Contains(searchTerm)).ToList();

        public Customer GetCustomer(int customerId) => Customers.FirstOrDefault(x => x.CustomerId == customerId);

        public bool CreateCustomer(string customerName, string legalId, string address, string zipCode, string city,
                  string region = "", string country = "", string phoneNumber = "")
        {
            try
            {
                var customerId = 1001;
                if (Accounts.Count != 0)
                {
                    customerId = Accounts.OrderByDescending(x => x.AccountId).Select(x => x.AccountId).First() + 1;
                }
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

                foreach (var property in customer.GetType().GetProperties())
                {
                    if (property.Name == nameof(customer.Region) || property.Name == nameof(customer.Country) ||
                        property.Name == nameof(customer.PhoneNumber)) continue;
                    if (string.IsNullOrEmpty(property.GetValue(customer).ToString()))
                    {
                        throw new NullReferenceException();
                    }
                }
                Customers.Add(customer);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool CreateCustomer(int customerId, string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "")
        {
            try
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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = Customers.FirstOrDefault(x => x.CustomerId == customerId);
                Customers.Remove(customer);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Account> GetAllAccounts() => Accounts;

        public bool CreateAccount(int customerId)
        {
            try
            {
                if (string.IsNullOrEmpty(customerId.ToString())) return false;
                var accountId = 0001;
                if (Accounts.Count != 0)
                {
                    accountId = Accounts.OrderByDescending(x => x.AccountId).Select(x => x.AccountId).First() + 1;
                }

                var account = new Account
                {
                    CustomerId = customerId,
                    Balance = 0,
                    AccountId = accountId
                };
                Accounts.Add(account);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool CreateAccount(int accountId, int customerId, decimal balance)
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
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool DeleteAccount(int accountId)
        {
            try
            {
                var account = Accounts.FirstOrDefault(x => x.AccountId == accountId);
                Accounts.Remove(account);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
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

        public bool UpdateBalance(int accountId, decimal newBalance)
        {
            try
            {
                var account = Accounts.First(x => x.AccountId == accountId);
                account.Balance = newBalance;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateBalance(int fromAccountId, int toAccountId, decimal fromAccountNewBalance, decimal toAccountNewBalance)
        {
            try
            {
                Accounts.First(x => x.AccountId == toAccountId).Balance = toAccountNewBalance;
                Accounts.First(x => x.AccountId == fromAccountId).Balance = toAccountNewBalance;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }
}

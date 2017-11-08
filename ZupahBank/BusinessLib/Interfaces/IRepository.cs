﻿using System;
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
        void CreateCustomer(int customerId,
            string customerName,
            string legalId,
            string address,
            string zipCode,
            string city,
            string region = "",
            string country = "",
            string phoneNumber = "");
        void DeleteCustomer(int customerId);
        List<Account> GetAllAccounts();
        void CreateAccount(int accountId, int customerId, decimal balance);
        void DeleteAccount(int accountId);
        decimal GetBalance(int accountId);
        void UpdateBalance(int accountId, decimal newBalance);
        void UpdateBalance(int fromAccountId, int toAccountId, decimal fromAccountNewBalance, decimal toAccountNewBalance);
    }
}

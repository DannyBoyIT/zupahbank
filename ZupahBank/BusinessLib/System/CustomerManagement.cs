﻿using BusinessLib.Interfaces;
using System;
using System.Collections.Generic;
using BusinessLib.Models;

namespace BusinessLib.System
{
    public class CustomerManagement : ICustomerManagement
    {
        private IRepository _repo;

        public CustomerManagement(IRepository repo)
        {
            _repo = repo;
        }

        public List<Customer> AllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public void Create(string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "")
        {
            _repo.CreateCustomer(customerName, legalId, address, zipCode, city,
                region, country, phoneNumber);
        }

        public void Delete(int customerId)
        {
            _repo.DeleteCustomer(customerId);
        }

        public Customer Edit(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Search(string searchTerm)
        {
            return _repo.SearchCustomer(searchTerm);
        }
        

    }
}

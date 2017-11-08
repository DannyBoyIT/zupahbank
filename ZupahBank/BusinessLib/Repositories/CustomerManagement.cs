using BusinessLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Models;

namespace BusinessLib.Repositories
{
    class CustomerManagement : ICustomerManagement
    {
        private IRepository _repo;

        private List<Customer> _customers { get; set; }

        public CustomerManagement(IRepository repo)
        {
            _repo = repo;
        }

        public List<Customer> AllCustomers()
        {
            throw new NotImplementedException();
        }

        public void Create(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Create(string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "")
        {
            _repo.CreateCustomer(customerName, legalId, address, zipCode, city,
                region, country, phoneNumber);
        }

        public void Delete(int customerId)
        {
            throw new NotImplementedException();
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

using BusinessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Interfaces
{
    public interface ICustomerManagement
    {
        bool Create(string customerName, string legalId, string address, string zipCode, string city,
            string region = "", string country = "", string phoneNumber = "");
        bool Delete(int customerId);
        Customer Edit(int customerId);
        List<Customer> AllCustomers();
        List<Customer> Search(string searchTerm);
    }
}

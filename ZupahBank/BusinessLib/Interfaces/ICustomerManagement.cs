using BusinessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Interfaces
{
    interface ICustomerManagement
    {
        void Create(string name, string legalId);
        void Delete(string legalId);
        Customer Edit(string legalId);
        Customer Search(string search);
        List<Customer> AllCustomers();
    }
}

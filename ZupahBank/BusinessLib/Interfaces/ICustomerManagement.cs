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
        void Create();
        void Delete();
        Customer Search(string searchText);
        Customer ShowCustomer(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib.Models;

namespace BusinessLib.Interfaces
{
    public interface IRepository
    {
        List<Customer> GetCustomers();
    }
}

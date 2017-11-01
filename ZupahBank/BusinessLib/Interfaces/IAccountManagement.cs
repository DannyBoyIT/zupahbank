using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Interfaces
{
    public interface IAccountManagement
    {
        void Create(int customerId);
        void Delete(int accountId);
    }
}

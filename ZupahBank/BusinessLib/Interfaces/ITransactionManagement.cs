using BusinessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Interfaces
{
    interface ITransactionManagement
    {
        bool CreateTransaction(int fromAccountId, int toAccountId, decimal amount);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int Amount { get; set; }
        // TODO: Add to- and from-account
    }
}

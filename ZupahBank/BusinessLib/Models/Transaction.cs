using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Models
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public Account ToAccount { get; set; }
        public Account FromAccount { get; set; }
    }
}

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLib.Interfaces;
using BusinessLib.Models;
using BusinessLib.Services;
using System;

namespace BusinessLib.Repositories
{
    public sealed class FileRepository : IRepository
    {

        private static volatile FileRepository _instance;
        private static readonly object SyncRoot = new object();

        private FileRepository() { }

        public static FileRepository Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new FileRepository();
                }
                return _instance;
            }
        }

        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public int NumberOfAccounts => Accounts.Count;
        public int NumberOfCustomers => Customers.Count;
        public decimal TotalBalance => Accounts.Sum(account => account.Balance);
    }
}

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLib.Interfaces;
using BusinessLib.Models;
using BusinessLib.Services;
using static System.Int32;

namespace BusinessLib.Repositories
{
    public class FileRepository : IRepository
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void TransformFileToLists(string path)
        {
            var fileService = new FileService();
            var file = fileService.ReadFromFile(path);

            var customerCount = Parse(file[0]);
            //var accountStartIndex = 0;

            for (var i = 1; i < customerCount + 1; i++)
            {
                var customerProps = file[i].Split(';');
                var customer = new Customer
                {
                    CustomerId = Parse(customerProps[0]),
                    LegalId = customerProps[1],
                    CustomerName = customerProps[2],
                    Address = customerProps[3],
                    City = customerProps[4],
                    ZipCode = customerProps[6]
                };
                if (customerProps[5].Length > 1)
                {
                    customer.Region = customerProps[5];
                }
                if (customerProps[7].Length > 1)
                {
                    customer.Country = customerProps[7];
                }
                if (customerProps[8].Length > 1)
                {
                    customer.PhoneNumber = customerProps[8];
                }
                Customers.Add(customer);
            }
            //var accountCount = Int32.Parse(file[customerCount + 1]);
            for (var i = customerCount + 2; i < file.Length; i++)
            {
                var accountProps = file[i].Split(';');
                var account = new Account
                {
                    AccountId = Parse(accountProps[0]),
                    CustomerId = Parse(accountProps[1]),
                    Balance = decimal.Parse(accountProps[2], NumberStyles.Currency, CultureInfo.InvariantCulture)
                };
                Accounts.Add(account);
            }

        }

        public void AddAccount(Account account)
        {

        }

        public void AddCustomer(Customer customer)
        {

        }

        public void AddTransaction(Transaction transaction)
        {

        }
    }
}

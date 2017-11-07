using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLib.Models;
using BusinessLib.Repositories;

namespace BusinessLib.Services
{
    public class FileService
    {
        public string[] ReadFromFile(string path)
        {
            try
            {
                var file = File.ReadAllLines(path);
                return file;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void WriteNewFile(string[] file)
        {
            try
            {
                var fileName = DateTime.Now.ToString("yyyyMMdd-Hmm");
                var path = $".\\Files\\{fileName}.txt";
                File.WriteAllLines(path, file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void TransformFileToLists(FileRepository repo, string path)
        {
            var file = ReadFromFile(path);

            var customerCount = int.Parse(file[0]);
            //var accountStartIndex = 0;

            for (var i = 1; i < customerCount + 1; i++)
            {
                var customerProps = file[i].Split(';');
                var customer = new Customer
                {
                    CustomerId = int.Parse(customerProps[0]),
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
                repo.Customers.Add(customer);
            }
            //var accountCount = Parse(file[customerCount + 1]);
            for (var i = customerCount + 2; i < file.Length; i++)
            {
                var accountProps = file[i].Split(';');
                var account = new Account
                {
                    AccountId = int.Parse(accountProps[0]),
                    CustomerId = int.Parse(accountProps[1]),
                    Balance = decimal.Parse(accountProps[2], NumberStyles.Currency, CultureInfo.InvariantCulture)
                };
                repo.Accounts.Add(account);
            }
        }

        public void TransformListsToFile(FileRepository repo, List<Account> accounts, List<Customer> customers)
        {

        }
    }
}

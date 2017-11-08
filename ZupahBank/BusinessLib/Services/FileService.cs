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

                var customerId = int.Parse(customerProps[0]);
                var legalId = customerProps[1];
                var customerName = customerProps[2];
                var address = customerProps[3];
                var city = customerProps[4];
                var zipCode = customerProps[6];
                var region = "";
                var country = "";
                var phoneNumber = "";
                if (customerProps[5].Length > 1)
                {
                    region = customerProps[5];
                }
                if (customerProps[7].Length > 1)
                {
                    country = customerProps[7];
                }
                if (customerProps[8].Length > 1)
                {
                    phoneNumber = customerProps[8];
                }
                repo.CreateCustomer(customerId, customerName, legalId,address, zipCode, city, region, country, phoneNumber);
            }
            //var accountCount = Parse(file[customerCount + 1]);
            for (var i = customerCount + 2; i < file.Length; i++)
            {
                var accountProps = file[i].Split(';');
                var accountId = int.Parse(accountProps[0]);
                var customerId = int.Parse(accountProps[1]);
                var balance = decimal.Parse(accountProps[2], NumberStyles.Currency, CultureInfo.InvariantCulture);
                repo.CreateAccount(accountId, customerId, balance);
            }
        }

        public void TransformListsToFile(FileRepository repo, List<Account> accounts, List<Customer> customers)
        {

        }
    }
}

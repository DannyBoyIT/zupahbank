using BusinessLib.System;
using BusinessLib.Services;
using System;
using System.Text.RegularExpressions;
using BusinessLib.Models;
using System.Collections.Generic;
using BusinessLib.Repositories;

namespace ZupahBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @".\Files\" + args[0];            
            var fileService = new FileService(); 
            var repo = FileRepository.Instance;
            fileService.TransformFileToRepo(repo, path);


            Console.WriteLine("******************************");
            Console.WriteLine("* VÄLKOMMEN TILL BANKAPP 1.0 *");
            Console.WriteLine("******************************");
            Console.WriteLine();
            Console.WriteLine("Antal kunder: " + repo.NumberOfCustomers());
            Console.WriteLine("Antal konton: " + repo.NumberOfAccounts());
            Console.WriteLine("Totalt saldo: " + repo.TotalBalance());


            int userInput = -1;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        CaseSearchCustomer(repo);
                        break;

                    case 2:
                        CaseGetCustomer(repo);
                        break;


                    case 3:
                        CaseCreateCustomer(repo);
                        break;


                    case 4:
                        CaseDeleteCustomer(repo);
                        break;


                    case 5:
                        CaseCreateAccount(repo);
                        break;

                    case 6:
                        CaseDeleteAccount(repo);
                        break;

                    case 7:
                        CaseDeposit(repo);
                        break;

                    case 8:
                        CaseWithdrawal(repo);
                        break;

                    case 9:
                        CaseTransaction(repo);
                        break;

                    case -1:
                        Console.WriteLine("Ogiltigt menyval");
                        break;
                }
            } while (userInput != 0);

            SaveChanges(repo);
            Console.ReadKey();
        }

        static int DisplayMenu()
        {

            Console.WriteLine();
            Console.WriteLine("HUVUDMENY");
            Console.WriteLine("0) Avsluta och spara");
            Console.WriteLine("1) Sök kund");
            Console.WriteLine("2) Visa kundbild");
            Console.WriteLine("3) Skapa kund");
            Console.WriteLine("4) Ta bort kund");
            Console.WriteLine("5) Skapa konto");
            Console.WriteLine("6) Ta bort konto");
            Console.WriteLine("7) Uttag");
            Console.WriteLine("8) Insättning");
            Console.WriteLine("9) Överföring");
            var result = Console.ReadKey(true).KeyChar;

            if (char.IsDigit(result))
            {
                return Convert.ToInt32(result.ToString());

            }
            else
                return -1;


        }

        //Case 0
        static void SaveChanges(FileRepository repo)
        {
            Console.WriteLine("> 0");
            Console.WriteLine("Avsluta och spara");
            Console.WriteLine("Sparar till ");
            Console.WriteLine("Antal kunder: " + repo.NumberOfCustomers());
            Console.WriteLine("Antal konton: " + repo.NumberOfAccounts());
            Console.WriteLine("Totalt saldo: " + repo.TotalBalance());
        }

        //Case 1
        static void CaseSearchCustomer(FileRepository repo)
        {
            Console.WriteLine("> 1");
            Console.WriteLine("* Sök kund *");
            Console.Write("Namn eller postort?");
            var inputSearch = Console.ReadLine();
            var resultSearch = repo.SearchCustomer(inputSearch);
            foreach (var item in resultSearch)
            {
                Console.WriteLine(item.CustomerId + ": " + item.CustomerName);
            }
            
        }

        //Case 2
        static void CaseGetCustomer(FileRepository repo)
        {
            Console.WriteLine("> 2");
            Console.WriteLine("* Visa kundbild *");
            Console.Write("Kundnummer? ");

            var inputGetCustomer = Console.ReadLine();
            bool successfullyParsed = int.TryParse(inputGetCustomer, out int getCustomer);
            if (successfullyParsed)
            {
                var customer = repo.GetCustomer(getCustomer);


                if (customer != null)
                {
                    Console.WriteLine("Kundnummer: " + customer.CustomerId);
                    Console.WriteLine("Namn: " + customer.CustomerName);
                    Console.WriteLine("Personnummer: " + customer.LegalId);
                    Console.WriteLine("Adress: " + customer.Address);
                    Console.WriteLine("Postnummer: " + customer.ZipCode);
                    Console.WriteLine("Ort: " + customer.City);
                    Console.WriteLine("Region: " + customer.Region);
                    Console.WriteLine("Land: " + customer.Country);

                    foreach (var account in repo.GetAllAccounts())
                    {
                        if (account.CustomerId == customer.CustomerId)
                        {
                            Console.WriteLine(account.AccountId + ": " + account.Balance);
                        }
                     
                    }
                }

                else
                {
                    Console.WriteLine("Kunden finns inte.");
                }

            }
            else
            {
                Console.WriteLine("Felaktig inmatning.");
            }
        }


        //Case 3
        static void CaseCreateCustomer(FileRepository repo)
        {
            Console.WriteLine("> 3");
            Console.WriteLine("* Skapa kund *");
            Console.Write("Namn: ");
            var inputCustomerName = Console.ReadLine();
            Console.Write("Personnummer: ");
            var inputCustomerLegalId = Console.ReadLine();
            Console.Write("Address: ");
            var inputCustomerAddress = Console.ReadLine();
            Console.Write("ZipCode: ");
            var inputCustomerZipCode = Console.ReadLine();
            Console.Write("City: ");
            var inputCustomerCity = Console.ReadLine();
            Console.Write("Region: ");
            var inputCustomerRegion = Console.ReadLine();
            Console.Write("Country: ");
            var inputCustomerCountry = Console.ReadLine();
            Console.Write("Phonenumber: ");
            var inputCustomerPhoneNumber = Console.ReadLine();
            var newCustomer = repo.CreateCustomer(inputCustomerName, inputCustomerLegalId, inputCustomerAddress, inputCustomerZipCode, inputCustomerCity, inputCustomerRegion, inputCustomerCountry, inputCustomerPhoneNumber);
        }

        //Case 4 
        static void CaseDeleteCustomer(FileRepository repo)
        {
            Console.WriteLine("> 4");
            Console.WriteLine("* Ta bort kund *");
            Console.Write("Kundnummer: ");
            var inputCustomerId = Console.ReadLine();
            bool successfullyParsed = int.TryParse(inputCustomerId, out int deletedCustomerId);
            if (successfullyParsed)
            {
                if (repo.DeleteCustomer(deletedCustomerId))
                {
                    Console.WriteLine("Kunden " + deletedCustomerId + " är borttagen.");
                }
                else
                    Console.WriteLine("Felaktigt kundnummer");
            }
            else
                Console.WriteLine("Felaktig inmatning");

        }

        //Case 5
        static void CaseCreateAccount(FileRepository repo)
        {
            Console.WriteLine("> 5");
            Console.WriteLine("* Skapa konto *");          
            Console.Write("Kundnummer: ");
            var inputCustomerId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Saldo: ");
            //var inputBalance = Convert.ToDecimal(Console.ReadLine());
            repo.CreateAccount(inputCustomerId);

        }

        //Case 6
        static void CaseDeleteAccount(FileRepository repo)
        {
            Console.WriteLine("> 6");
            Console.WriteLine("* Ta bort konto *");
            Console.Write("Kontonummer: ");
            var inputAccountId = Console.ReadLine();
            repo.DeleteAccount(Convert.ToInt32(inputAccountId));
        }

        //Case 7
        static void CaseDeposit(FileRepository repo)
        {
            Console.WriteLine("> 7");
            Console.WriteLine("* Insättning *");
            Console.Write("Till konto? ");
            var inputAccountId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Belopp? ");
            var inputAmount = Convert.ToInt32(Console.ReadLine());

            //TODO metod för Insättning();
        }
        //Case 8
        static void CaseWithdrawal(FileRepository repo)
        {
            Console.WriteLine("> 8");
            Console.WriteLine("* Uttag *");
            Console.Write("Från konto? ");
            var inputAccountId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Belopp? ");
            var inputAmount = Convert.ToInt32(Console.ReadLine());
            //TODO metod för Uttag()


        }
        //Case 9
        static void CaseTransaction(FileRepository repo)
        {
            Console.WriteLine("> 9");
            Console.WriteLine("* Överföring *");
            Console.Write("Från? ");
            var inputFromAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Till? ");
            var inputToAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Belopp? ");
            var inputAmount = Convert.ToInt32(Console.ReadLine());
            repo.UpdateBalance(inputFromAccount, inputToAccount, inputAmount, inputAmount);
            //TODO Metod för Overföring()

        }
    }
}

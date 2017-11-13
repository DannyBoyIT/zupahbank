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
        private static BankSystem _system;

        static void Main(string[] args)
        {
            string path = @".\Files\" + args[0];            
            var fileService = new FileService(); 
            var repo = FileRepository.Instance;
            _system = new BankSystem(repo);
            fileService.TransformFileToRepo(repo, path);


            Console.WriteLine("******************************");
            Console.WriteLine("* VÄLKOMMEN TILL BANKAPP 1.0 *");
            Console.WriteLine("******************************");
            Console.WriteLine();
            Console.WriteLine("Antal kunder: " + _system.customerManagement.GetNumberOfCustomers());
            Console.WriteLine("Antal konton: " + _system.accountManagement.GetNumberOfAccounts());
            Console.WriteLine("Totalt saldo: " + _system.accountManagement.TotalBalance());


            int userInput = -1;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        CaseSearchCustomer(_system);
                        break;

                    case 2:
                        CaseGetCustomer(_system);
                        break;


                    case 3:
                        CaseCreateCustomer(_system);
                        break;


                    case 4:
                        CaseDeleteCustomer(_system);
                        break;


                    case 5:
                        CaseCreateAccount(_system);
                        break;

                    case 6:
                        CaseDeleteAccount(_system);
                        break;

                    case 7:
                        CaseDeposit(_system);
                        break;

                    case 8:
                        CaseWithdrawal(_system);
                        break;

                    case 9:
                        CaseTransaction(_system);
                        break;

                    case -1:
                        Console.WriteLine("Ogiltigt menyval");
                        break;
                }
            } while (userInput != 0);

            CaseSaveChangesAndExit(fileService, repo);
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
        static void CaseSaveChangesAndExit(FileService fileService, FileRepository repo)
        {
            Console.WriteLine("> 0");
            Console.WriteLine("Avsluta och spara");
            Console.WriteLine("Sparar till " + fileService.TransformRepoToFile(repo) + ".txt...");
            Console.WriteLine("Antal kunder: " + _system.customerManagement.GetNumberOfCustomers());
            Console.WriteLine("Antal konton: " + _system.accountManagement.GetNumberOfAccounts());
            Console.WriteLine("Totalt saldo: " + _system.accountManagement.TotalBalance());
        }

        //Case 1
        static void CaseSearchCustomer(BankSystem bankSystem)
        {
            Console.WriteLine("> 1");
            Console.WriteLine("* Sök kund *");
            Console.Write("Namn eller postort?");
            var inputSearch = Console.ReadLine();
            var resultSearch = bankSystem.customerManagement.Search(inputSearch);
            foreach (var item in resultSearch)
            {
                Console.WriteLine(item.CustomerId + ": " + item.CustomerName);
            }
            
        }

        //Case 2
        static void CaseGetCustomer(BankSystem bankSystem)
        {
            Console.WriteLine("> 2");
            Console.WriteLine("* Visa kundbild *");
            Console.Write("Kundnummer? ");

            var inputGetCustomer = Console.ReadLine();
            bool successfullyParsed = int.TryParse(inputGetCustomer, out int customerId);
            if (successfullyParsed)
            {
                var customer = bankSystem.customerManagement.GetCustomer(customerId);

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

                    foreach (var account in bankSystem.accountManagement.AllAccounts())
                        //foreach (var account in repo.GetAllAccounts())
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
        static void CaseCreateCustomer(BankSystem bankSystem)
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
            var newCustomer = bankSystem.customerManagement.Create(inputCustomerName, inputCustomerLegalId, inputCustomerAddress, inputCustomerZipCode, inputCustomerCity, inputCustomerRegion, inputCustomerCountry, inputCustomerPhoneNumber);
            //var newCustomer = repo.CreateCustomer(inputCustomerName, inputCustomerLegalId, inputCustomerAddress, inputCustomerZipCode, inputCustomerCity, inputCustomerRegion, inputCustomerCountry, inputCustomerPhoneNumber);
        }

        //Case 4 
        static void CaseDeleteCustomer(BankSystem bankSystem)
        {
            Console.WriteLine("> 4");
            Console.WriteLine("* Ta bort kund *");
            Console.Write("Kundnummer: ");
            var inputCustomerId = Console.ReadLine();
            bool successfullyParsed = int.TryParse(inputCustomerId, out int deletedCustomerId);
            if (successfullyParsed)
            {
                bankSystem.customerManagement.Delete(deletedCustomerId);
                if (bankSystem.customerManagement.Delete(deletedCustomerId))
                //if (repo.DeleteCustomer(deletedCustomerId))
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
        static void CaseCreateAccount(BankSystem bankSystem)
        {
            Console.WriteLine("> 5");
            Console.WriteLine("* Skapa konto *");          
            Console.Write("Kundnummer: ");
            var inputCustomerId = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Saldo: ");
            //var inputBalance = Convert.ToDecimal(Console.ReadLine());
            //repo.CreateAccount(inputCustomerId);
            bankSystem.accountManagement.Create(inputCustomerId);

        }

        //Case 6
        static void CaseDeleteAccount(BankSystem bankSystem)
        {
            Console.WriteLine("> 6");
            Console.WriteLine("* Ta bort konto *");
            Console.Write("Kontonummer: ");
            var inputAccountId = Console.ReadLine();
            //repo.DeleteAccount(Convert.ToInt32(inputAccountId));
            var response = bankSystem.accountManagement.Delete(Convert.ToInt32(inputAccountId));
            Console.WriteLine(response ? "Kontot raderat" : "Saldot på kontot är ej noll, går ej radera");
        }

        //Case 7
        static void CaseDeposit(BankSystem bankSystem)
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
        static void CaseWithdrawal(BankSystem bankSystem)
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
        static void CaseTransaction(BankSystem bankSystem)
        {
            Console.WriteLine("> 9");
            Console.WriteLine("* Överföring *");
            Console.Write("Från? ");
            var inputFromAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Till? ");
            var inputToAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Belopp? ");
            var inputAmount = Convert.ToInt32(Console.ReadLine());
            bankSystem.transactionManagement.CreateTransaction(inputFromAccount, inputToAccount, inputAmount);
        }
    }
}

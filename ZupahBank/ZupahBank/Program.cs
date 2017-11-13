using BusinessLib.System;
using BusinessLib.Services;
using System;
using BusinessLib.Repositories;
using System.Globalization;

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
            Console.WriteLine("7) Insättning");
            Console.WriteLine("8) Uttag");
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

            int customerId = 0;
            bool successfullyParsed = false;
            while (customerId == 0)
            {
                Console.Write("Kundnummer? ");

                var inputGetCustomer = Console.ReadLine();
                successfullyParsed = int.TryParse(inputGetCustomer, out customerId);
            }

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
            Console.Write("Adress: ");
            var inputCustomerAddress = Console.ReadLine();
            Console.Write("Postkod: ");
            var inputCustomerZipCode = Console.ReadLine();
            Console.Write("Ort: ");
            var inputCustomerCity = Console.ReadLine();
            Console.Write("Region: ");
            var inputCustomerRegion = Console.ReadLine();
            Console.Write("Land: ");
            var inputCustomerCountry = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            var inputCustomerPhoneNumber = Console.ReadLine();
            var newCustomer = bankSystem.customerManagement.Create(inputCustomerName, inputCustomerLegalId, inputCustomerAddress, inputCustomerZipCode, inputCustomerCity, inputCustomerRegion, inputCustomerCountry, inputCustomerPhoneNumber);
            Console.WriteLine(newCustomer ? "Användaren skapad" : "Användare ej skapad");
        }

        //Case 4 
        static void CaseDeleteCustomer(BankSystem bankSystem)
        {
            bool successfullyParsed;

            do
            {
                Console.WriteLine();
                Console.WriteLine("> 4");
                Console.WriteLine("* Ta bort kund *");
                Console.Write("Kundnummer: ");
                var inputCustomerId = Console.ReadLine();
                successfullyParsed = int.TryParse(inputCustomerId, out int deletedCustomerId);
                if (successfullyParsed)
                {
                    if (bankSystem.customerManagement.Delete(deletedCustomerId))
                    {
                        Console.WriteLine("Kunden " + deletedCustomerId + " är borttagen.");
                    }
                    else
                        Console.WriteLine("Felaktigt kundnummer");
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning");
                    Console.WriteLine("Tryck 0 för att komma till menyn annars tryck enter för att försöka igen.");

                    if (Console.ReadKey(true).KeyChar == '0')
                        break;
                }                   

            } while(!successfullyParsed);
        }

        //Case 5
        static void CaseCreateAccount(BankSystem bankSystem)
        {
            bool successfullyParsed;

            do
            {
                Console.WriteLine();
                Console.WriteLine("> 5");
                Console.WriteLine("* Skapa konto *");
                Console.Write("Kundnummer: ");
                var inputCustomerId = Console.ReadLine();
                successfullyParsed = int.TryParse(inputCustomerId, out int customerId);
                if (successfullyParsed)
                {
                    var customer = bankSystem.customerManagement.GetCustomer(customerId);
                    if (customer != null)
                    {
                        var result = bankSystem.accountManagement.Create(customerId);
                        Console.WriteLine(result
                            ? $"Nytt konto för kundnummer {customerId} skapat."
                            : "Nåt gick fel, försök igen");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Felaktigt kundnummer");
                        Console.WriteLine("Tryck 0 för att komma till menyn annars tryck enter för att försöka igen.");

                        if (Console.ReadKey(true).KeyChar == '0')
                            break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Felaktig inmatning");
                    Console.WriteLine("Tryck 0 för att komma till menyn annars tryck enter för att försöka igen.");

                    if (Console.ReadKey(true).KeyChar == '0')
                        break;
                }

            } while (!successfullyParsed);
        }

        //Case 6
        static void CaseDeleteAccount(BankSystem bankSystem)
        {
            bool successfullyParsedAccountId;

            do
            {
                Console.WriteLine();
                Console.WriteLine("> 6");
                Console.WriteLine("* Ta bort konto *");
                Console.Write("Kontonummer: ");
                var inputAccountId = Console.ReadLine();
                successfullyParsedAccountId = int.TryParse(inputAccountId, out int accountId);
                if (successfullyParsedAccountId)
                {
                    var response = bankSystem.accountManagement.Delete(accountId);
                    Console.WriteLine(response ? "Kontot borttaget." : "Saldot på kontot är ej noll, går ej att radera.");
                }
                else
                {
                    Console.WriteLine("Felaktigt nummer, kontrollera att du skrivit in rätt kontonummer.");
                    Console.WriteLine("Tryck 0 för att komma till menyn annars tryck enter för att försöka igen.");

                    if (Console.ReadKey(true).KeyChar == '0')
                        break;
                }

            } while (!successfullyParsedAccountId);
        }

        //Case 7
        static void CaseDeposit(BankSystem bankSystem)
        {
            bool successfullyParsedAccountId;
            bool successfullyParsedAmount;

            do
            {
                Console.WriteLine();
                Console.WriteLine("> 7");
                Console.WriteLine("* Insättning *");
                Console.Write("Till konto? ");
                var inputAccountId = Console.ReadLine();
                Console.Write("Belopp? ");
                var inputAmount = Console.ReadLine();
                successfullyParsedAccountId = int.TryParse(inputAccountId, out int accountId);
                successfullyParsedAmount = decimal.TryParse(inputAmount, out decimal amount);

                if (successfullyParsedAccountId && successfullyParsedAmount)
                {
                    var withdrawalAccepted = bankSystem.accountManagement.Deposit(accountId, amount);
                    Console.WriteLine();
                    Console.WriteLine(withdrawalAccepted ? $"Instättningen på: {inputAmount}kr till konto: {inputAccountId} lyckades." : $"Insättningen misslyckades. Kontrollera att du anget rätt kontonummer ({inputAccountId}).");
                }

                else
                {
                    Console.WriteLine("Felaktig inmatning. Kontrollera att du angett rätt kontonummber och summa.");

                    Console.WriteLine("Tryck 0 för att komma till menyn annars tryck enter för att försöka igen.");

                    if (Console.ReadKey(true).KeyChar == '0')
                        break;
                }

            } while (!successfullyParsedAccountId || !successfullyParsedAmount);
        }

        //Case 8
        static void CaseWithdrawal(BankSystem bankSystem)
        {
            bool successfullyParsedAccountId;
            bool successfullyParsedAmount;

            do
            {
                Console.WriteLine();
                Console.WriteLine("> 8");
                Console.WriteLine("* Uttag *");
                Console.Write("Från konto? ");
                var inputAccountId = Console.ReadLine();
                Console.Write("Belopp? ");
                var inputAmount = Console.ReadLine();
                successfullyParsedAccountId = int.TryParse(inputAccountId, out int accountId);
                successfullyParsedAmount = decimal.TryParse(inputAmount, out decimal amount);

                if (successfullyParsedAccountId && successfullyParsedAmount)
                {
                    var withdrawalAccepted = bankSystem.accountManagement.Withdraw(accountId, amount);
                    Console.WriteLine();
                    Console.WriteLine(withdrawalAccepted ? $"Uttag på: {amount}kr från konto: {accountId} lyckades." : $"Uttaget misslyckades. Kontrollera att dina tillgångar (på konto: {accountId}) tillåter uttaget och att kontonumret är korrekt.");
                }

                else
                {
                    Console.WriteLine("Felaktig inmatning. Kontrollera att du angett rätt kontonummber och summa.");
                    Console.WriteLine("Tryck 0 för att komma till menyn annars tryck enter för att försöka igen.");

                    if (Console.ReadKey(true).KeyChar == '0')
                        break;
                }

            } while (!successfullyParsedAccountId || !successfullyParsedAmount);
        }

        //Case 9
        static void CaseTransaction(BankSystem bankSystem)
        {
            Console.WriteLine("> 9");
            Console.WriteLine("* Överföring *");

            int inputFromAccount = -1;
            while (inputFromAccount == -1)
            {
                Console.Write("Från? ");
                try
                {
                    inputFromAccount = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ogiltigt kontonummer");
                }
            }

            int inputToAccount = -1;
            while (inputToAccount == -1)
            {
                Console.Write("Till? ");
                try
                {
                    inputToAccount = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ogiltigt kontonummer");
                }
            }

            decimal inputAmount = 0m;
            while (inputAmount == 0m)
            {
                Console.Write("Belopp? ");
                try
                {
                    inputAmount = Decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine("Ogiltig summa");
                }
            }

            var transactionResult = bankSystem.transactionManagement.CreateTransaction(inputFromAccount, inputToAccount, inputAmount);

            Console.WriteLine(transactionResult ? "Transaktion klar" : "Transaktion misslyckad");
        }
    }
}

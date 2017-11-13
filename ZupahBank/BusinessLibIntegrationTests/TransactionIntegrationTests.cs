using BusinessLib.Repositories;
using BusinessLib.Services;
using BusinessLib.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BusinessLibIntegrationTests
{
    public class TransactionIntegrationTests
    {
        [Fact]
        public void CanCreateTransaction()
        {
            var repo = FileRepository.Instance;
            var service = new FileService();
            const string path = @".\Files\bankdata-small.txt";
            service.TransformFileToRepo(repo, path);

            var sut = new BankSystem(repo);
            var fromAccountNo = 13130;
            var toAccountNo = 13020;

            Assert.Equal(false, 
                sut.transactionManagement.CreateTransaction(fromAccountNo, toAccountNo, 5000));

            Assert.Equal(false,
                sut.transactionManagement.CreateTransaction(fromAccountNo, toAccountNo, -500));

            Assert.Equal(true, 
                sut.transactionManagement.CreateTransaction(fromAccountNo, toAccountNo, 500));

            var allAccounts = sut.accountManagement.AllAccounts();

            var account1 = allAccounts.Single(x => x.AccountId == fromAccountNo);
            var account2 = allAccounts.Single(x => x.AccountId == toAccountNo);

            Assert.Equal(4307.00m, account1.Balance);
            Assert.Equal(1113.20m, account2.Balance);

        }
        
    }
}

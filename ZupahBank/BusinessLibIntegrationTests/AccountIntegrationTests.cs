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
    public class AccountIntegrationTests
    {
        [Fact]
        public void CanWithdrawAndDeposit()
        {
            var repo = FileRepository.Instance;
            var service = new FileService();
            const string path = @".\Files\bankdata-small.txt";
            service.TransformFileToRepo(repo, path);

            var sut = new BankSystem(repo);
            var accountNo = 13130;

            Assert.Equal(false, sut.accountManagement.Withdraw(accountNo, 5000));
            Assert.Equal(false, sut.accountManagement.Withdraw(accountNo, -5000));
            Assert.Equal(false, sut.accountManagement.Deposit(accountNo, -5000));

            sut.accountManagement.Withdraw(accountNo, 1000);
            var account = repo.GetAccount(accountNo);
            Assert.Equal(3807.00m, account.Balance);

            sut.accountManagement.Deposit(accountNo, 1000);
            Assert.Equal(4807.00m, account.Balance);
        }
    }
}

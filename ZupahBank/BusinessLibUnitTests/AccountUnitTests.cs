using System;
using System.Collections.Generic;
using System.Text;
using BusinessLib.Repositories;
using BusinessLib.System;
using Xunit;

namespace BusinessLibUnitTests
{
    public class AccountUnitTests
    {
        [Fact]
        public void CanCreateAccount()
        {
            var repo = FileRepository.Instance;
            var sut = new BankSystem(repo);
            var acc = sut.accountManagement.Create(1);
            Assert.True(acc);
        }

        [Fact]
        public void CanDeleteAccount()
        {
            var repo = FileRepository.Instance;
            var sut = new BankSystem(repo);
            var acc = sut.accountManagement.Create(1000);
            var del = sut.accountManagement.Delete(1001);
            Assert.True(del);
        }

        [Fact]
        public void CanGetAllAccounts()
        {
            var repo = FileRepository.Instance;
            var sut = new BankSystem(repo);
            var acc = sut.accountManagement.Create(1000);
            var acc2 = sut.accountManagement.Create(1001);
            var acc3 = sut.accountManagement.Create(1002);
            var acc4 = sut.accountManagement.Create(1003);
            var list = sut.accountManagement.AllAccounts();
            Assert.Equal(4, list.Count);
        }
    }
}

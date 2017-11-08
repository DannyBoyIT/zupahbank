using BusinessLib.Models;
using BusinessLib.Repositories;
using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Xunit;

namespace BusinessLibUnitTests
{
    public class FileRepositoryTests
    {
        [Fact]
        public void PropertyCanCountNumberOfAccounts()
        {
            var sut = FileRepository.Instance;
            sut.CreateAccount(1000, 1000, 1000);
            sut.CreateAccount(1001, 1001, 1000);
            Assert.Equal(2, sut.NumberOfAccounts());
        }

        [Fact]
        public void PropertyCanCountNumberOfCustomers()
        {
            var sut = FileRepository.Instance;
            sut.CreateCustomer(1000, "Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            sut.CreateCustomer(1001, "Varor och sånt", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            Assert.Equal(2, sut.NumberOfCustomers());
        }

        [Fact]
        public void PropertyCanCountTotalBalance()
        {
            var sut = FileRepository.Instance;
            sut.CreateAccount(1000, 1000, 1000);
            sut.CreateAccount(1000, 1000, 500);
            Assert.Equal(1500, sut.TotalBalance());
        }

        [Fact]
        public void CanAddAccount()
        {

        }

        [Fact]
        public void CanAddCustomer()
        {

        }
        [Fact]
        public void CanAddTransaction()
        {

        }
    }
}

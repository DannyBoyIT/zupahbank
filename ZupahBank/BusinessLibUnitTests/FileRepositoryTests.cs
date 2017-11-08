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
        public void CanCountNumberOfAccounts()
        {
            var sut = FileRepository.Instance;
            sut.CreateAccount(1000);
            sut.CreateAccount(1001);
            Assert.Equal(2, sut.NumberOfAccounts());
        }

        [Fact]
        public void CanCountNumberOfCustomers()
        {
            var sut = FileRepository.Instance;
            sut.CreateCustomer("Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            sut.CreateCustomer("Varor och sånt", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            Assert.Equal(2, sut.NumberOfCustomers());
        }

        [Fact]
        public void CanCountTotalBalance()
        {
            var sut = FileRepository.Instance;
            sut.CreateAccount(1001, 1000, 1000);
            sut.CreateAccount(1001, 1000, 500);
            Assert.Equal(1500, sut.TotalBalance());
        }

        [Fact]
        public void CanCreateNewAccount()
        {
            var sut = FileRepository.Instance;
            sut.CreateAccount(1000);

        }

        [Fact]
        public void CanCreateNewAccountWithId()
        {
            var sut = FileRepository.Instance;
            sut.CreateAccount(1001, 1000, 1000);

        }
        [Fact]
        public void CanCreateNewCustomer()
        {
            var sut = FileRepository.Instance;
            sut.CreateCustomer("Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
        }
        [Fact]
        public void CannotCreateNewCustomerWithoutLegalId()
        {
            var sut = FileRepository.Instance;
            sut.CreateCustomer("Isabellas Varor", "", "Hejsanvägen 5", "10520", "Stockholm");
        }

        [Fact]
        public void CanCreateNewCustomerWithId()
        {
            var sut = FileRepository.Instance;
            sut.CreateCustomer(1001, "Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
        }
    }
}

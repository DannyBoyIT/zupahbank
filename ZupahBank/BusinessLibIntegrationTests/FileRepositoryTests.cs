using BusinessLib.Models;
using BusinessLib.Repositories;
using BusinessLib.Services;
using System;
using System.IO;
using Xunit;
using Xunit.Sdk;

namespace BusinessLibIntegrationTests
{
    public class FileRepositoryTests
    {
        [Fact]
        public void PropertyCanCountNumberOfAccounts()
        {
            //var sut = FileRepository.Instance;
            //sut.Accounts.Add(new Account
            //{
            //    AccountId = 1000,
            //    CustomerId = 1000,
            //    Balance = 1000
            //});
            //sut.Accounts.Add(new Account
            //{
            //    AccountId = 1001,
            //    CustomerId = 1001,
            //    Balance = 1000
            //});
            //Assert.Equal(sut.Accounts.Count, sut.NumberOfAccounts);
        }

        [Fact]
        public void PropertyCanCountNumberOfCustomers()
        {

        }

        [Fact]
        public void PropertyCanCountTotalBalance()
        {

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

        [Fact]
        public void CanSearchForCustomer()
        {
            var sut = FileRepository.Instance;

            sut.CreateCustomer(1234, "Kalle Kallesson", "801010-1010", "L�nggatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");

            var customers = sut.SearchCustomer("Kalle");

            Assert.Equal(1, customers.Count);
        }
    }
}

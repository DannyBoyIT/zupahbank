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
        public void CanTransformFileToLists()
        {
            var sut = new FileRepository();
            var path = @".\Files\bankdata-small.txt";
            sut.TransformFileToLists(path);
            Assert.Equal(3, sut.Customers.Count);
            Assert.Equal(5, sut.Accounts.Count);
        }

        [Fact]
        public void PropertyCanCountNumberOfAccounts()
        {
            var sut = new FileRepository();
            sut.Accounts.Add(new Account
            {
                AccountId = 1000,
                CustomerId = 1000,
                Balance = 1000
            });
            sut.Accounts.Add(new Account
            {
                AccountId = 1001,
                CustomerId = 1001,
                Balance = 1000
            });
            Assert.Equal(sut.Accounts.Count, sut.NumberOfAccounts);
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
    }
}

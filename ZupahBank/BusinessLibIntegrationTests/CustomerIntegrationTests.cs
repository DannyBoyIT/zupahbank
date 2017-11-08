using BusinessLib.Repositories;
using BusinessLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BusinessLibIntegrationTests
{
    class CustomerIntegrationTests
    {
        [Fact]
        public void CanSearchForCustomer()
        {
            var sut = FileRepository.Instance;

            sut.CreateCustomer("Kalle Kallesson", "801010-1010", "Långgatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");

            var customers = sut.SearchCustomer("Kalle");

            Assert.Equal(1, customers.Count);
        }

        [Fact]
        public void NewCustomerGetsAValidId()
        {
            var sut = FileRepository.Instance;
            var service = new FileService();
            const string path = @".\Files\bankdata-small.txt";
            service.TransformFileToRepo(sut, path);

            sut.CreateCustomer("Kalle Kallesson", "801010-1010", "Långgatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");

            Assert.Equal(1033, sut.GetAllCustomers().LastOrDefault()?.CustomerId);
        }
    }
}

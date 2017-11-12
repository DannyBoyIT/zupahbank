using BusinessLib.Repositories;
using BusinessLib.Services;
using BusinessLib.System;
using System.Linq;
using Xunit;

namespace BusinessLibIntegrationTests
{
    public class CustomerIntegrationTests
    {
        [Fact]
        public void NewCustomerGetsAValidId()
        {
            var repo = FileRepository.Instance;
            var system = new BankSystem(repo);
            var service = new FileService();
            const string path = @".\Files\bankdata-small.txt";

            service.TransformFileToRepo(repo, path);

            system.customerManagement.Create("Kalle Kallesson", "801010-1010", "Långgatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");

            Assert.Equal(1033, system.customerManagement.AllCustomers().LastOrDefault()?.CustomerId);
        }
    }
}

using BusinessLib.Repositories;
using BusinessLib.System;
using Xunit;

namespace BusinessLibUnitTests
{
    public class CustomerUnitTests
    {
        [Fact]
        public void CanSearchForCustomer()
        {
            var repo = FileRepository.Instance;
            var system = new BankSystem(repo);

            system.customerManagement.Create("Kalle Kallesson", "801010-1010", "Långgatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");

            var customers = system.customerManagement.Search("Kalle");

            Assert.Equal(1, customers.Count);
        }
    }
}

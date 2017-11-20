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

            Assert.Single(customers);
        }

        [Fact]
        public void CanDeleteCustomer()
        {
            var repo = FileRepository.Instance;
            var system = new BankSystem(repo);

            system.customerManagement.Create("Kalle Kallesson", "801010-1010", "Långgatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");
            system.customerManagement.Create("Micke Makaroni", "760219-4117", "Gatan 1", "11352", "Rinkeby", "Stockholm", "Sverige", "0732185733");
            system.customerManagement.Create("John Doe", "990419-5748", "Lincoln St. 3465", "34621", "Manhattan", "New York", "USA", "9675483922");

            system.customerManagement.Delete(1002);

            var customers = system.customerManagement.AllCustomers();

            Assert.Equal(2, customers.Count);
        }
    }
}

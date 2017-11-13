using BusinessLib.Repositories;
using System.Linq;
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
            var expectedResult = sut.NumberOfCustomers() + 2;
            sut.CreateCustomer("Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            sut.CreateCustomer("Varor och sånt", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            Assert.Equal(expectedResult, sut.NumberOfCustomers());
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
            bool response = sut.CreateAccount(1000);
            Assert.True(response);
        }

        [Fact]
        public void CanCreateNewAccountWithId()
        {
            var sut = FileRepository.Instance;
            bool response = sut.CreateAccount(1001, 1000, 1000);
            Assert.True(response);
        }
        [Fact]
        public void CanCreateNewCustomer()
        {
            var sut = FileRepository.Instance;
            bool response = sut.CreateCustomer("Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            Assert.True(response);
        }
        [Fact]
        public void CannotCreateNewCustomerWithoutLegalId()
        {
            var sut = FileRepository.Instance;
            bool response = sut.CreateCustomer("Isabellas Varor", "", "Hejsanvägen 5", "10520", "Stockholm");
            Assert.False(response);
        }

        [Fact]
        public void CanCreateNewCustomerWithId()
        {
            var sut = FileRepository.Instance;
            bool response = sut.CreateCustomer(1001, "Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            Assert.True(response);
        }

        [Fact]
        public void CanSearchForCustomerName()
        {
            var sut = FileRepository.Instance;
            const string expectedResult = "Kalle Kallesson";
            bool response = sut.CreateCustomer(1234, expectedResult, "801010-1010", "Långgatan 1", "11122", "Huvudsta", "Stockholm", "Sverige", "010111222");
            var customers = sut.SearchCustomer("Kalle");

            var kalle = customers.First(x => x.CustomerName.Contains("Kalle"));
            Assert.Equal(expectedResult, kalle.CustomerName);
        }
    }
}

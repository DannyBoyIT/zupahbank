using BusinessLib.Interfaces;

namespace BusinessLib.System
{
    public class BankSystem
    {
        public readonly AccountManagement accountManagement;
        public readonly CustomerManagement customerManagement;
        public readonly TransactionManagement transactionManagement;

        public BankSystem(IRepository repository)
        {
            accountManagement = new AccountManagement(repository);
            customerManagement = new CustomerManagement(repository);
            transactionManagement = new TransactionManagement(repository);
        }
    }
}


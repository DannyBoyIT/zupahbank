using BusinessLib.Interfaces;

namespace BusinessLib.System
{
    public class BankSystem
    {
        public readonly AccountManagement accountManagement;

        public BankSystem(IRepository repository)
        {
            accountManagement = new AccountManagement(repository);
            //Othe management classes will be instansiated here
        }
    }
}


using BusinessLib.Interfaces;

namespace BusinessLib.System
{
    public class TransactionManagement
    {
        private readonly IRepository _repo;

        public TransactionManagement(IRepository repo)
        {
            _repo = repo;
        }

        //Method for making a transaction
    }
}

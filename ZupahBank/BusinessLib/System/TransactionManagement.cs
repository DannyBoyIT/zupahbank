using BusinessLib.Interfaces;

namespace BusinessLib.System
{
    public class TransactionManagement : ITransactionManagement
    {
        private readonly IRepository _repo;

        public TransactionManagement(IRepository repo)
        {
            _repo = repo;
        }

        public bool CreateTransaction(int fromAccountId, int toAccountId, decimal amount)
        {
            if(amount < 0)
            {
                return false;
            }

            var fromAccountNewBalance = _repo.GetBalance(fromAccountId) - amount;

            if(fromAccountNewBalance < 0)
            {
                return false;
            }

            var toAccountNewBalance = _repo.GetBalance(toAccountId) + amount;

            return _repo.UpdateBalance(fromAccountId, toAccountId, fromAccountNewBalance, toAccountNewBalance);
        }
        
    }
}

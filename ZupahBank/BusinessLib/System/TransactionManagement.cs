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

            decimal fromAccountNewBalance, toAccountNewBalance;

            try { 

                fromAccountNewBalance = _repo.GetBalance(fromAccountId) - amount;

                if(fromAccountNewBalance < 0)
                {
                    return false;
                }

                toAccountNewBalance = _repo.GetBalance(toAccountId) + amount;

            }
            catch
            {
                return false;
            }

            return _repo.UpdateBalance(fromAccountId, toAccountId, fromAccountNewBalance, toAccountNewBalance);
        }
        
    }
}

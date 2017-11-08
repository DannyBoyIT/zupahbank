using BusinessLib.Repositories;

namespace BusinessLib.System
{
    public class BankSystem
    {
        private readonly FileRepository _fileRepository;
        public readonly AccountManagement accountManagement;

        public BankSystem()
        {
            _fileRepository = FileRepository.Instance;
            accountManagement = new AccountManagement(_fileRepository);
        }
    }
}

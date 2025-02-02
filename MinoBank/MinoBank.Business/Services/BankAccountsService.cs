using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;
using MinoBank.Core.Enums.BankCard;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankAccountsService : IBankAccountsService
    {
        private readonly IBankAccountsRepository _bankAccountsRepo;
        private readonly IUsersRepository _usersRepo;
        public BankAccountsService(IBankAccountsRepository bankAccountsRepo, IUsersRepository usersRepo)
        {
            _bankAccountsRepo = bankAccountsRepo;
            _usersRepo = usersRepo;
        }

        public async Task<List<BankAccount>> GetAllBankAccountsAsync()
        {
            return await _bankAccountsRepo.GetAllBankAccountsAsync();
        }

        public async Task<List<BankAccount>> GetBankAccountsByUserAsync(Guid userId)
        {
            var bankAccounts = await _bankAccountsRepo.GetBankAccountsByUserIdAsync(userId)
                ?? throw new ArgumentException("This user doesn't have any bank accounts");
            return bankAccounts;
        }

        public async Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId)
        {
            // Get bank account by specificated ID
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId)
                ?? throw new ArgumentException($"Bank account with ID {bankAccountId} not found.");

            // Return bank account
            return bankAccount;
        }

        public async Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(Guid bankAccountId)
        {
            // Get bank account by specificated ID
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId)
                ?? throw new ArgumentException($"Bank account with ID {bankAccountId} not found.");

            // Get details of the bank account
            var bankAccountDetails = bankAccount.Details
                ?? throw new ArgumentException($"Details of bank account with ID {bankAccountId} not found.");

            return bankAccountDetails;
        }

        public async Task<List<BankCard>> GetBankCardsByIdAsync(Guid bankAccountId)
        {
            // Get bank account by specificated ID
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId)
                ?? throw new ArgumentException($"Bank account with ID {bankAccountId} not found.");

            // Get bank cards of the bank account
            var bankAccountCards = bankAccount.BankCards
                ?? throw new ArgumentException($"Cards of bank account with ID {bankAccountId} not found.");

            return bankAccountCards;
        }

        public async Task CreateBankAccountAsync(Guid userId, BankAccountType type)
        {
            // Get user by id
            var user = await _usersRepo.GetUserByIdAsync(userId)
                ?? throw new ArgumentException($"User with ID {userId} not found.");

            // Get bank accounts by user
            var bankAccounts = await _bankAccountsRepo.GetBankAccountsByUserIdAsync(userId);

            // Check if bank account with this type already exist
            if (bankAccounts != null && bankAccounts.Any(a => a.Type == type))
            {
                throw new ArgumentException($"Bank account with type {type} already exists");
            }

            // Create a bank account
            var bankAccount = BankAccount.Create(user, type);

            // Add the bank account
            await _bankAccountsRepo.CreateBankAccountAsync(bankAccount);
        }

        public async Task DeleteBankAccountByIdAsync(Guid bankAccountId)
        {
            await _bankAccountsRepo.DeleteBankAccountByIdAsync(bankAccountId);
        }

        public async Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus)
        {
            await _bankAccountsRepo.UpdateBankAccountStatusByIdAsync(bankAccountId, newStatus);
        }
    }
}
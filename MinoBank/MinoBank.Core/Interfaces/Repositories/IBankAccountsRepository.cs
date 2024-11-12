using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankAccountsRepository
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<BankAccount> GetBankAccountByIdAsync(int bankAccountId);
        Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(int bankAccountId);
        Task CreateBankAccountAsync(BankAccount newBankAccount);
        Task<bool> DeleteBankAccountByIdAsync(int bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(int bankAccountId, BankAccountStatus newStatus);
    }
}
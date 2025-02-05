using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankAccountsRepository
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<List<BankAccount>> GetBankAccountsByUserIdAsync(string userId);
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task CreateBankAccountAsync(BankAccount newBankAccount);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
        Task SaveChangesAsync();
    }
}
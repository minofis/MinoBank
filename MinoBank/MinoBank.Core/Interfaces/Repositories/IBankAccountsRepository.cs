using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankAccountsRepository
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<List<BankAccount>> GetBankAccountsByUserIdAsync(Guid userId);
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task CreateBankAccountAsync(BankAccount newBankAccount);
        Task DeleteBankAccountByIdAsync(Guid bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
        Task SaveChangesAsync();
    }
}
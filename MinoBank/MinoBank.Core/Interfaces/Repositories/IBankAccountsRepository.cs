using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankAccountsRepository
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task<BankAccount> GetBankAccountByBankCardNumber(string bankCardNumber);
        Task CreateBankAccountAsync(BankAccount newBankAccount);
        Task DeleteBankAccountByIdAsync(Guid bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
        Task SaveChangesAsync();
    }
}
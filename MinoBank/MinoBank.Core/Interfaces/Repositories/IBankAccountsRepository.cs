using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankAccountsRepository
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task CreateBankAccountAsync(BankAccount newBankAccount);
        Task DeleteBankAccountByIdAsync(Guid bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
        Task UpdateBankAccountTypeByIdAsync(Guid bankAccountId, BankAccountType newType);
    }
}
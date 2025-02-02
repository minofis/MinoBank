using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankAccountsService
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<List<BankAccount>> GetBankAccountsByUserAsync(Guid userId);
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(Guid bankAccountId);
        Task<List<BankCard>> GetBankCardsByIdAsync(Guid bankAccountId);
        Task CreateBankAccountAsync(Guid userId, BankAccountType type);
        Task DeleteBankAccountByIdAsync(Guid bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
    }
}
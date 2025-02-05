using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankAccountsService
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<List<BankAccount>> GetBankAccountsByUserIdAsync(string userId);
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(Guid bankAccountId);
        Task<List<BankCard>> GetBankCardsByIdAsync(Guid bankAccountId);
        Task CreateBankAccountAsync(string userId, BankAccountType type);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
    }
}
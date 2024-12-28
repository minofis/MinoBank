using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankAccountsService
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(Guid bankAccountId);
        Task CreateBankAccountAsync(BankAccount bankAccount);
        Task DeleteBankAccountByIdAsync(Guid bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
        Task UpdateBankAccountTypeByIdAsync(Guid bankAccountId, BankAccountType newType);
    }
}
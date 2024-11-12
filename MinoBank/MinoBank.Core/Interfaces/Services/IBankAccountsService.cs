using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankAccountsService
    {
        Task CreateBankAccountAsync(BankAccount bankAccount);
        Task<bool> DeleteBankAccountByIdAsync(int bankAccountId);
        Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(int bankAccountId);
        Task ChangeBankAccountStatusByIdAsync(int bankAccountId, BankAccountStatus newStatus);
    }
}
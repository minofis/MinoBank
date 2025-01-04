using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankAccountsService
    {
        Task<List<BankAccount>> GetAllBankAccountsAsync();
        Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId);
        Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(Guid bankAccountId);
        Task<List<BankCard>> GetBankCardsByIdAsync(Guid bankAccountId);
        Task TransferMoneyToBankCardByNumberAsync(Guid bankAccountId, BankTransaction newBankTransaction, string senderBankCardNumber, string recipientBankCardNumber);
        Task CreateBankAccountAsync(BankAccount bankAccount);
        Task CreateBankCardByIdAsync(Guid bankAccountId, BankCardType bankCardType, BankCardCurrencyCode currencyCode);
        Task DeleteBankAccountByIdAsync(Guid bankAccountId);
        Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus);
    }
}
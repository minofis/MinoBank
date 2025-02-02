using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankCardsService
    {
        Task<List<BankCard>> GetAllBankCardsAsync();
        Task<BankCard> GetBankCardByIdAsync(Guid bankCardId);
        Task<BankCardDetails> GetBankCardDetailsByIdAsync(Guid bankCardId);
        Task<List<BankTransaction>> GetSentTransactionsByIdAsync(Guid bankCardId);
        Task<List<BankTransaction>> GetRecivedTransactionsByIdAsync(Guid bankCardId);
        Task TopUpBankCardByIdAsync(Guid bankCardId, decimal topUpAmount);
        Task FundsTransferToBankCardByIdAsync(Guid bankCardId, BankTransaction newBankTransaction);
        Task CreateBankCardAsync(Guid userId, Guid bankAccountId, BankCardType type, CurrencyCode currencyCode);
        Task DeleteBankCardByIdAsync(Guid bankCardId);
        Task UpdateBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus);
        Task UpdateBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode);
    }
}
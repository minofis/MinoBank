using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankCardsService
    {
        Task<List<BankCard>> GetAllBankCardsAsync();
        Task<BankCard> GetBankCardByIdAsync(Guid bankCardId);
        Task<BankCardDetails> GetBankCardDetailsByIdAsync(Guid bankCardId);
        Task TopUpBankCardByIdAsync(Guid bankCardId, BankTransaction newBankTransaction);
        Task CreateBankCardAsync(BankCard newBankCard);
        Task DeleteBankCardByIdAsync(Guid bankCardId);
        Task UpdateBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus);
        Task UpdateBankCardDailyLimitByIdAsync(Guid bankCardId, decimal newDailyLimit);
        Task UpdateBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode);
    }
}
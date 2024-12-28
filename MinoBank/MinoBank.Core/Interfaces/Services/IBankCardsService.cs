using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCards;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankCardsService
    {
        Task CreateBankCardAsync(BankCard bankCard);
        Task<BankCardDetails> GetBankCardDetailsByIdAsync(Guid bankCardId);
        Task<bool> DeleteBankCardByIdAsync(Guid bankCardId);
        Task ChangeBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus);
        Task ChangeBankCardLimitByIdAsync(Guid bankCardId, decimal newLimit, BankCardLimitType limitType);
        Task ChangeBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode);
    }
}
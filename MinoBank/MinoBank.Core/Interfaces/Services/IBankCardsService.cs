using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCards;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankCardsService
    {
        Task CreateBankCardAsync(BankCard bankCard);
        Task<BankCardDetails> GetBankCardDetailsByIdAsync(int bankCardId);
        Task<bool> DeleteBankCardByIdAsync(int bankCardId);
        Task ChangeBankCardStatusByIdAsync(int bankCardId, BankCardStatus newStatus);
        Task ChangeBankCardLimitByIdAsync(int bankCardId, decimal newLimit, BankCardLimitType limitType);
        Task ChangeBankCardPinCodeByIdAsync(int bankCardId, string newPinCode);
    }
}
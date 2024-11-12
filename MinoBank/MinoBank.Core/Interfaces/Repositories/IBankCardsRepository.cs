using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCards;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankCardsRepository
    {
        Task<BankCardDetails> GetBankCardByIdAsync(int bankCardId);
        Task CreateBankCardAsync(BankCard bankCard);
        Task<bool> DeleteBankCardByIdAsync(int bankCardId);
        Task UpdateBankCardStatusByIdAsync(int bankCardId, BankCardStatus newStatus);
        Task UpdateBankCardLimitByIdAsync(int bankCardId, decimal newLimit, BankCardLimitType limitType);
        Task UpdateBankCardPinCodeByIdAsync(int bankCardId, string newPinCode);
    }
}
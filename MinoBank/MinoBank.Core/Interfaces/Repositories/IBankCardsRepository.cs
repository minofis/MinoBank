using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCards;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankCardsRepository
    {
        Task<BankCardDetails> GetBankCardByIdAsync(Guid bankCardId);
        Task CreateBankCardAsync(BankCard bankCard);
        Task<bool> DeleteBankCardByIdAsync(Guid bankCardId);
        Task UpdateBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus);
        Task UpdateBankCardLimitByIdAsync(Guid bankCardId, decimal newLimit, BankCardLimitType limitType);
        Task UpdateBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode);
    }
}
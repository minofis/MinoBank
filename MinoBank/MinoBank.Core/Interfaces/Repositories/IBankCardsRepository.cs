using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankCardsRepository
    {
        Task<List<BankCard>> GetAllBankCardsAsync();
        Task<BankCard> GetBankCardByIdAsync(Guid bankCardId);
        Task CreateBankCardAsync(BankCard newBankCard);
        Task DeleteBankCardByIdAsync(Guid bankCardId);
        Task UpdateBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus);
        Task UpdateBankCardDailyLimitByIdAsync(Guid bankCardId, decimal newDailyLimit);
        Task UpdateBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode);
        Task SaveChangesAsync();
    }
}
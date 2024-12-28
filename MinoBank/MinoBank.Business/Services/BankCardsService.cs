using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCards;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankCardsService : IBankCardsService
    {
        public Task CreateBankCardAsync(BankCard bankCard)
        {
            throw new NotImplementedException();
        }

        public Task<BankCardDetails> GetBankCardDetailsByIdAsync(Guid bankCardId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBankCardByIdAsync(Guid bankCardId)
        {
            throw new NotImplementedException();
        }

        public Task ChangeBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public Task ChangeBankCardLimitByIdAsync(Guid bankCardId, decimal newLimit, BankCardLimitType limitType)
        {
            throw new NotImplementedException();
        }
        public Task ChangeBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode)
        {
            throw new NotImplementedException();
        }
    }
}
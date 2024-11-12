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

        public Task<BankCardDetails> GetBankCardDetailsByIdAsync(int bankCardId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBankCardByIdAsync(int bankCardId)
        {
            throw new NotImplementedException();
        }

        public Task ChangeBankCardStatusByIdAsync(int bankCardId, BankCardStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public Task ChangeBankCardLimitByIdAsync(int bankCardId, decimal newLimit, BankCardLimitType limitType)
        {
            throw new NotImplementedException();
        }
        public Task ChangeBankCardPinCodeByIdAsync(int bankCardId, string newPinCode)
        {
            throw new NotImplementedException();
        }
    }
}
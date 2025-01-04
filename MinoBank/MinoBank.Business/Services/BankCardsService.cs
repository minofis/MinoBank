using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCard;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankCardsService : IBankCardsService
    {
        private readonly IBankCardsRepository _bankCardsRepo;
        public BankCardsService(IBankCardsRepository bankCardsRepo)
        {
            _bankCardsRepo = bankCardsRepo;
        }
        
        public async Task<List<BankCard>> GetAllBankCardsAsync()
        {
            return await _bankCardsRepo.GetAllBankCardsAsync();
        }

        public async Task<BankCard> GetBankCardByIdAsync(Guid bankCardId)
        {
            return await _bankCardsRepo.GetBankCardByIdAsync(bankCardId);
        }

        public async Task<BankCardDetails> GetBankCardDetailsByIdAsync(Guid bankCardId)
        {
            var bankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId);
            return bankCard.Details;
        }

        public async Task CreateBankCardAsync(BankCard newBankCard)
        {
            await _bankCardsRepo.CreateBankCardAsync(newBankCard);
        }

        public async Task DeleteBankCardByIdAsync(Guid bankCardId)
        {
            await _bankCardsRepo.DeleteBankCardByIdAsync(bankCardId);
        }

        public async Task UpdateBankCardDailyLimitByIdAsync(Guid bankCardId, decimal newDailyLimit)
        {
            await _bankCardsRepo.UpdateBankCardDailyLimitByIdAsync(bankCardId, newDailyLimit);
        }

        public async Task UpdateBankCardPinCodeByIdAsync(Guid bankCardId, string newPinCode)
        {
            await _bankCardsRepo.UpdateBankCardPinCodeByIdAsync(bankCardId, newPinCode);
        }

        public async Task UpdateBankCardStatusByIdAsync(Guid bankCardId, BankCardStatus newStatus)
        {
            await _bankCardsRepo.UpdateBankCardStatusByIdAsync(bankCardId, newStatus);
        }
    }
}
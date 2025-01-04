using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCard;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankCardsService : IBankCardsService
    {
        private readonly IBankCardsRepository _bankCardsRepo;
        private readonly IBankTransactionsRepository _bankTransactionsRepo;
        public BankCardsService(IBankCardsRepository bankCardsRepo, IBankTransactionsRepository bankTransactionsRepo)
        {
            _bankCardsRepo = bankCardsRepo;
            _bankTransactionsRepo = bankTransactionsRepo;
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

        public async Task TopUpBankCardByIdAsync(Guid bankCardId, BankTransaction newBankTransaction)
        {
            // Get bank card by id
            var bankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found");

            // Create bank transaction
            var bankTransaction = new BankTransaction
            {
                Name = $"Top-up for {bankCard.Details.OwnerName}",
                CurrencyCode = newBankTransaction.CurrencyCode,
                Type = newBankTransaction.Type,
                Description = "Funds added to bank card balance",
                Amount = newBankTransaction.Amount,
                SenderBankCardId = Guid.Empty,
                RecipientBankCardId = bankCard.Id
            };

            // Update balance
            bankCard.Balance += bankTransaction.Amount;

            // Add bank transaction to bank card
            bankCard.RecivedTransactions.Add(bankTransaction);

            // Save changes
            await _bankTransactionsRepo.CreateBankTransactionAsync(bankTransaction);
            await _bankCardsRepo.SaveChangesAsync();
        }
    }
}
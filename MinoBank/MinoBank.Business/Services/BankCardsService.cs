using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankCard;
using MinoBank.Core.Enums.BankTransaction;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankCardsService : IBankCardsService
    {
        private readonly IBankCardsRepository _bankCardsRepo;
        private readonly IBankAccountsRepository _bankAccountsRepo;
        private readonly IBankTransactionsRepository _bankTransactionsRepo;
        public BankCardsService(IBankCardsRepository bankCardsRepo, IBankAccountsRepository bankAccountsRepo, IBankTransactionsRepository bankTransactionsRepo)
        {
            _bankCardsRepo = bankCardsRepo;
            _bankTransactionsRepo = bankTransactionsRepo;
            _bankAccountsRepo = bankAccountsRepo;
        }
        
        public async Task<List<BankCard>> GetAllBankCardsAsync()
        {
            return await _bankCardsRepo.GetAllBankCardsAsync();
        }

        public async Task<BankCard> GetBankCardByIdAsync(Guid bankCardId)
        {
            // Get bank card by specificated ID
            var bankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found.");

            // Return bank card
            return bankCard;
        }

        public async Task<BankCardDetails> GetBankCardDetailsByIdAsync(Guid bankCardId)
        {
            // Get bank card by specificated ID
            var bankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found.");

            // Get details of the bank card
            var bankCardDetails = bankCard.Details
                ?? throw new ArgumentException($"Details of bank card with ID {bankCardId} not found.");
            
            // Return bank card details
            return bankCardDetails;
        }

        public async Task<List<BankTransaction>> GetSentTransactionsByIdAsync(Guid bankCardId)
        {
            // Get bank card by specificated ID
            var bankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found.");

            // Get sent transactions of the bank card
            var sentTransactions = bankCard.SentTransactions
                ?? throw new ArgumentException($"Sent transactions of bank card with ID {bankCardId} not found.");

            // Return sent transactions
            return sentTransactions;
        }

        public async Task<List<BankTransaction>> GetRecivedTransactionsByIdAsync(Guid bankCardId)
        {
            // Get bank card by specificated ID
            var bankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found.");

            // Get recived transactions of the bank card
            var recivedTransactions = bankCard.RecivedTransactions
                ?? throw new ArgumentException($"Recived transactions of bank card with ID {bankCardId} not found.");

            // Return recived transactions
            return recivedTransactions;
        }

        public async Task TopUpBankCardByIdAsync(Guid bankCardId, decimal topUpAmount)
        {
            // Get recipient bank card
            var recipientBankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found.");

            // Update balance
            recipientBankCard.IncreaseBalance(topUpAmount);

            // Create bank transaction
            var bankTransaction = new BankTransaction
            {
                Name = $"Top-up for {recipientBankCard.Details.OwnerName}",
                CurrencyCode = recipientBankCard.Details.CurrencyCode,
                Category = BankTransactionCategory.TopUp,
                Description = "Funds added to bank card balance.",
                Amount = topUpAmount,
                RecipientBankCardId = recipientBankCard.Id
            };

            // Add transaction to bank card
            recipientBankCard.RecivedTransactions.Add(bankTransaction);

            // Save changes
            await _bankTransactionsRepo.CreateBankTransactionAsync(bankTransaction);
            await _bankCardsRepo.SaveChangesAsync();
        }

        public async Task FundsTransferToBankCardByIdAsync(Guid bankCardId, BankTransaction newBankTransaction)
        {
            // Get recipient and sender bank cards
            var senderBankCard = await _bankCardsRepo.GetBankCardByIdAsync(bankCardId)
                ?? throw new ArgumentException($"Bank card with ID {bankCardId} not found.");
            
            var recipientBankCard = await _bankCardsRepo.GetBankCardByIdAsync(newBankTransaction.RecipientBankCardId)
                ?? throw new ArgumentException($"Bank card with ID {newBankTransaction.RecipientBankCardId} not found.");

            // Check for balance of sender card
            if (senderBankCard.Balance < newBankTransaction.Amount)
                throw new ArgumentException($"You do not have enough money for this transaction.");

            // Update balances
            senderBankCard.ReduceBalance(newBankTransaction.Amount);
            recipientBankCard.IncreaseBalance(newBankTransaction.Amount);

            // Create the transaction
            var bankTransaction = new BankTransaction
            {
                Name = $"From {recipientBankCard.Details.OwnerName} to {recipientBankCard.Details.OwnerName}",
                Description = newBankTransaction.Description,
                Amount = newBankTransaction.Amount,
                Category = BankTransactionCategory.FundsTransfer,
                CurrencyCode = recipientBankCard.Details.CurrencyCode,
                SenderBankCardId = senderBankCard.Id,
                RecipientBankCardId = recipientBankCard.Id
            };

            // Add transaction to both cards
            senderBankCard.SentTransactions.Add(bankTransaction);
            recipientBankCard.RecivedTransactions.Add(bankTransaction);

            // Save changes
            await _bankTransactionsRepo.CreateBankTransactionAsync(bankTransaction);
            await _bankCardsRepo.SaveChangesAsync();
        }

        public async Task CreateBankCardAsync(Guid userId, Guid bankAccountId, BankCardType type, CurrencyCode currencyCode)
        {
            // Get bank account by id
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId)
                ?? throw new ArgumentException($"Bank account with ID {bankAccountId} not found.");

            if (bankAccount.UserId != userId)
            {
                throw new ArgumentException($"Access to bank account with ID {bankAccountId} is forbidden.");
            }

            var bankCard = BankCard.Create(Guid.NewGuid(), BankCardStatus.Active, type, bankAccountId, currencyCode, bankAccount.Details.OwnerName);
            
            await _bankCardsRepo.CreateBankCardAsync(bankCard);
        }

        public async Task DeleteBankCardByIdAsync(Guid bankCardId)
        {
            await _bankCardsRepo.DeleteBankCardByIdAsync(bankCardId);
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
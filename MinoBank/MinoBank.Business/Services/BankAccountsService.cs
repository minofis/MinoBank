using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccount;
using MinoBank.Core.Enums.BankCard;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankAccountsService : IBankAccountsService
    {
        private readonly IBankAccountsRepository _bankAccountsRepo;
        private readonly IBankTransactionsRepository _bankTransactionsRepo;
        private readonly IBankCardsRepository _bankCardsRepo;
        public BankAccountsService(IBankAccountsRepository bankAccountsRepo, IBankTransactionsRepository bankTransactionsRepo, IBankCardsRepository bankCardsRepo)
        {
            _bankAccountsRepo = bankAccountsRepo;
            _bankTransactionsRepo = bankTransactionsRepo;
            _bankCardsRepo = bankCardsRepo;
        }

        public async Task<List<BankAccount>> GetAllBankAccountsAsync()
        {
            return await _bankAccountsRepo.GetAllBankAccountsAsync();
        }

        public async Task<BankAccount> GetBankAccountByIdAsync(Guid bankAccountId)
        {
            return await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId);
        }

        public async Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(Guid bankAccountId)
        {
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId);
            return bankAccount.Details;
        }

        public async Task<List<BankCard>> GetBankCardsByIdAsync(Guid bankAccountId)
        {
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId);
            return bankAccount.BankCards;
        }

        public async Task TransferMoneyToBankCardByNumberAsync(Guid bankAccountId, BankTransaction newBankTransaction, string senderBankCardNumber, string recipientBankCardNumber)
        {
            // Get recipient and sender bank accounts
            var senderBankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId)
                ?? throw new ArgumentException($"Bank account with ID {bankAccountId} not found");

            var recipientBankAccount = await _bankAccountsRepo.GetBankAccountByBankCardNumber(recipientBankCardNumber)
                ?? throw new ArgumentException($"Bank account with bank card number {bankAccountId} not found");

            // Get recipient and sender bank cards
            var senderBankCard = senderBankAccount.BankCards
                .FirstOrDefault(c => c.Details.Number == senderBankCardNumber)
                ?? throw new ArgumentException($"Bank card with number {senderBankCardNumber} not found");
            
            var recipientBankCard = recipientBankAccount.BankCards
                .FirstOrDefault(c => c.Details.Number == recipientBankCardNumber)
                ?? throw new ArgumentException($"Bank card with number {recipientBankCardNumber} not found");

            // Check for balance of sender account
            if (senderBankCard.Balance < newBankTransaction.Amount)
                throw new ArgumentException($"You don't have enough money for this transaction");

            // Update balances
            senderBankCard.Balance -= newBankTransaction.Amount;
            recipientBankCard.Balance += newBankTransaction.Amount;

            // Create the transaction
            var bankTransaction = new BankTransaction
            {
                Name = $"From {senderBankAccount.Details.OwnerName} to {recipientBankAccount.Details.OwnerName}",
                Description = newBankTransaction.Description,
                Amount = newBankTransaction.Amount,
                CurrencyCode = newBankTransaction.CurrencyCode,
                SenderBankCardId = senderBankCard.Id,
                RecipientBankCardId = recipientBankCard.Id
            };

            // Add transaction to both cards
            senderBankCard.SentTransactions.Add(bankTransaction);
            recipientBankCard.RecivedTransactions.Add(bankTransaction);

            // Save changes
            await _bankTransactionsRepo.CreateBankTransactionAsync(bankTransaction);
            await _bankAccountsRepo.SaveChangesAsync();
        }

        public async Task CreateBankAccountAsync(BankAccount bankAccount)
        {
            await _bankAccountsRepo.CreateBankAccountAsync(bankAccount);
        }

        public async Task CreateBankCardByIdAsync(Guid bankAccountId, BankCardType bankCardType, BankCardCurrencyCode currencyCode)
        {
            var bankAccount = await _bankAccountsRepo.GetBankAccountByIdAsync(bankAccountId);
            var newBankCard = new BankCard
            {
                BankAccountId = bankAccountId,
                Type = bankCardType,
                Details = new BankCardDetails()
                {
                    CurrencyCode = currencyCode,
                    OwnerName = bankAccount.Details.OwnerName
                }
            };
            await _bankCardsRepo.CreateBankCardAsync(newBankCard);
        }

        public async Task DeleteBankAccountByIdAsync(Guid bankAccountId)
        {
            await _bankAccountsRepo.DeleteBankAccountByIdAsync(bankAccountId);
        }

        public async Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus)
        {
            await _bankAccountsRepo.UpdateBankAccountStatusByIdAsync(bankAccountId, newStatus);
        }
    }
}
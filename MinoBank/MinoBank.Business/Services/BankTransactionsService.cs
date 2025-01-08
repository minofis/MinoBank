using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankTransactionsService : IBankTransactionsService
    {
        private readonly IBankTransactionsRepository _bankTransactionsRepo;
        public BankTransactionsService(IBankTransactionsRepository bankTransactionsRepo)
        {
            _bankTransactionsRepo = bankTransactionsRepo;
        }

        public async Task<List<BankTransaction>> GetAllBankTransactionsAsync()
        {
            return await _bankTransactionsRepo.GetAllBankTransactionsAsync();
        }

        public async Task<BankTransaction> GetBankTransactionByIdAsync(Guid bankTransactionId)
        {
            // Get bank transaction by specificated ID
            var bankTransaction = await _bankTransactionsRepo.GetBankTransactionByIdAsync(bankTransactionId)
                ?? throw new ArgumentException($"Bank transaction with ID {bankTransactionId} not found.");

            // Return bank transaction
            return bankTransaction;
        }

        public async Task CreateBankTransactionAsync(BankTransaction newBankTransaction)
        {
            await _bankTransactionsRepo.CreateBankTransactionAsync(newBankTransaction);
        }

        public async Task DeleteBankTransactionByIdAsync(Guid bankTransactionId)
        {
            await _bankTransactionsRepo.DeleteBankTransactionByIdAsync(bankTransactionId);
        }
    }
}
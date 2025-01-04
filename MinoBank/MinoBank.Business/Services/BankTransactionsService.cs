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
            return await _bankTransactionsRepo.GetBankTransactionByIdAsync(bankTransactionId);
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
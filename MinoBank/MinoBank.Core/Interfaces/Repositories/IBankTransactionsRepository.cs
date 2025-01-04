using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Repositories
{
    public interface IBankTransactionsRepository
    {
        Task<List<BankTransaction>> GetAllBankTransactionsAsync();
        Task<BankTransaction> GetBankTransactionByIdAsync(Guid bankTransactionId);
        Task CreateBankTransactionAsync(BankTransaction newBankTransaction);
        Task DeleteBankTransactionByIdAsync(Guid bankTransactionId);
    }
}
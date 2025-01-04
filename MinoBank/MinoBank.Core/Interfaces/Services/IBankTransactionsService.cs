using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IBankTransactionsService
    {
        Task<List<BankTransaction>> GetAllBankTransactionsAsync();
        Task<BankTransaction> GetBankTransactionByIdAsync(Guid bankTransactionId);
        Task CreateBankTransactionAsync(BankTransaction newBankTransaction);
        Task DeleteBankTransactionByIdAsync(Guid bankTransactionId);
    }
}
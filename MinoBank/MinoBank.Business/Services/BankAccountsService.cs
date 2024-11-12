using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankAccountsService : IBankAccountsService
    {
        public Task CreateBankAccountAsync(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public Task<BankAccountDetails> GetBankAccountDetailsByIdAsync(int bankAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBankAccountByIdAsync(int bankAccountId)
        {
            throw new NotImplementedException();
        }

        public Task ChangeBankAccountStatusByIdAsync(int bankAccountId, BankAccountStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
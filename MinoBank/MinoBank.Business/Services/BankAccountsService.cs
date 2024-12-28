using MinoBank.Core.Entities;
using MinoBank.Core.Enums.BankAccounts;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class BankAccountsService : IBankAccountsService
    {
        private readonly IBankAccountsRepository _bankAccountsRepo;
        public BankAccountsService(IBankAccountsRepository bankAccountsRepo)
        {
            _bankAccountsRepo = bankAccountsRepo;
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

        public async Task CreateBankAccountAsync(BankAccount bankAccount)
        {
            await _bankAccountsRepo.CreateBankAccountAsync(bankAccount);
        }

        public async Task DeleteBankAccountByIdAsync(Guid bankAccountId)
        {
            await _bankAccountsRepo.DeleteBankAccountByIdAsync(bankAccountId);
        }

        public async Task UpdateBankAccountStatusByIdAsync(Guid bankAccountId, BankAccountStatus newStatus)
        {
            await _bankAccountsRepo.UpdateBankAccountStatusByIdAsync(bankAccountId, newStatus);
        }

        public async Task UpdateBankAccountTypeByIdAsync(Guid bankAccountId, BankAccountType newType)
        {
            await _bankAccountsRepo.UpdateBankAccountTypeByIdAsync(bankAccountId, newType);
        }
    }
}
using MinoBank.Core.Enums.BankAccounts;

namespace MinoBank.Core.Entities
{
    public class BankAccount : BaseEntity
    {
        public string BankName { get; set; } = string.Empty;
        public BankAccountStatus Status { get; set; }
        public List<BankCard> BankCards { get; set; }
        public BankAccountDetails Details { get; set; }
    }
}
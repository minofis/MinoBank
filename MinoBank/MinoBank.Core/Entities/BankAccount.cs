using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Entities
{
    public class BankAccount : BaseEntity
    {
        public BankAccountStatus Status { get; set; } = BankAccountStatus.Active;
        public BankAccountType Type { get; set; } = BankAccountType.Standart;
        public List<BankCard> BankCards { get; set; } = new List<BankCard>();
        public BankAccountDetails Details { get; set; } = new BankAccountDetails();
    }
}
using MinoBank.Core.Enums.BankCards;

namespace MinoBank.Core.Entities
{
    public class BankCard : BaseEntity
    {
        public BankCardStatus Status { get; set; }
        public decimal Balance { get; set; }
        public decimal DailyLimit { get; set; }
        public decimal MonthlyLimit { get; set; }
        public decimal AnnualLimit { get; set; }
        public int PinCode { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public BankAccount? BankAccount { get; set; }
        public Guid BankAccountId { get; set; }
        public BankCardDetails? Details { get; set; }
        public Guid DetailsId { get; set; }
    }
}
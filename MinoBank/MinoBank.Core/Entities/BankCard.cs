using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Entities
{
    public class BankCard 
    {
        public Guid Id { get; set; }
        public BankCardStatus Status { get; set; } = BankCardStatus.Active;
        public BankCardType Type { get; set; } = BankCardType.Standart;
        public decimal Balance { get; set; } = 0;
        public string PinCode { get; set; } = "0000";
        public decimal DailyLimit { get; set; } = 50;
        public decimal MonthlyLimit { get; set; } = 300;
        public decimal AnnualLimit { get; set; } = 1000;
        public List<BankTransaction> SentTransactions { get; set; } = new List<BankTransaction>();
        public List<BankTransaction> RecivedTransactions { get; set; } = new List<BankTransaction>();
        public BankCardDetails Details { get; set; } = new BankCardDetails();
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
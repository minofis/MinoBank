using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Entities
{
    public class BankCard 
    {
        public BankCard(){}
        public BankCard(Guid id, BankCardDetails details, BankCardStatus status, BankCardType type, decimal balance, string pinCode, List<BankTransaction> sentTransactions, List<BankTransaction> recivedTransactions, Guid bankAccountId)
        {
            Id = id;
            Details = details;
            Status = status;
            Type = type;
            Balance = balance;
            PinCode = pinCode;
            SentTransactions = sentTransactions;
            RecivedTransactions = recivedTransactions;
            BankAccountId = bankAccountId;
        }
        public Guid Id { get; set; }
        public BankCardStatus Status { get; private set; }
        public BankCardType Type { get; private set; }
        public decimal Balance { get; private set; }
        public string PinCode { get; private set; }
        public List<BankTransaction> SentTransactions { get; private set; }
        public List<BankTransaction> RecivedTransactions { get; private set; }
        public Guid BankAccountId { get; private set; }
        public BankAccount BankAccount { get; private set; }
        public BankCardDetails Details { get; private set; }

        public static BankCard Create(Guid id, BankCardStatus status, BankCardType type, Guid bankAccountId, CurrencyCode currencyCode, string ownerName)
        {
            var details = BankCardDetails.Create(id, currencyCode, ownerName, DateTime.UtcNow.ToUniversalTime());

            return new BankCard(id, details, status, type, 0, "0000", [], [], bankAccountId);
        }

        public void ReduceBalance(decimal amount)
        {
            Balance -= amount;
        }
        public void IncreaseBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}
using MinoBank.Core.Enums.Transactions;

namespace MinoBank.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }

        public TransactionCurrencyCode CurrencyCode { get; set; }
        public TransactionCategory Category { get; set; }
        public TransactionType Type { get; set; }
/*
        public BankAccount Recipient { get; set; }
        public Guid RecipientId { get; set; }
        public BankAccount Sender { get; set; }
        public Guid SenderId { get; set; }
*/
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
using MinoBank.Core.Enums.BankTransaction;

namespace MinoBank.Core.Entities
{
    public class BankTransaction : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public decimal Commission { get; set; } = 0;
        public BankTransactionCurrencyCode CurrencyCode { get; set; } = BankTransactionCurrencyCode.EUR;
        public BankTransactionCategory Category { get; set; } = BankTransactionCategory.Remittance;
        public BankTransactionType Type { get; set; } = BankTransactionType.Expense;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        // Sender 
        public Guid SenderBankCardId { get; set; }
        public BankCard SenderBankCard { get; set; }

        // Recipient 
        public Guid RecipientBankCardId { get; set; }
        public BankCard RecipientBankCard { get; set; }
    }
}
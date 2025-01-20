using MinoBank.Core.Enums.BankCard;
using MinoBank.Core.Enums.BankTransaction;

namespace MinoBank.Core.Entities
{
    public class BankTransaction : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public decimal Commission { get; set; } = 0;
        public CurrencyCode CurrencyCode { get; set; }
        public BankTransactionCategory Category { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now.ToUniversalTime();

        // Sender 
        public Guid? SenderBankCardId { get; set; }
        public BankCard? SenderBankCard { get; set; }

        // Recipient 
        public Guid RecipientBankCardId { get; set; }
        public BankCard RecipientBankCard { get; set; }
    }
}
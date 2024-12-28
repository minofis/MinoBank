using MinoBank.Core.Enums.BankCards;

namespace MinoBank.Core.Entities
{
    public class BankCardDetails
    {
        public Guid BankCardId { get; set; }
        public BankCardCurrencyCode CurrencyCode { get; set; }
        public string Number { get; set; } = string.Empty;
        public string CvvCode { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public BankCard BankCard { get; set; }
    }
}
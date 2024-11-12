namespace MinoBank.Core.Entities
{
    public class BankCardDetails : BaseEntity
    {
        public string Number { get; set; } = string.Empty;
        public string CvvCode { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
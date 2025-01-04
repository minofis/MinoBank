namespace MinoBank.API.Dtos.BankCardDtos
{
    public class BankCardDetailsResponseDto
    {
        public string CurrencyCode { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string CvvCode { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public Guid BankCardId { get; set; }
    }
}
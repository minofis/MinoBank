namespace MinoBank.API.Dtos.BankAccountDetails
{
    public class BankAccountDetailsResponseDto
    {
        public string BankName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public Guid BankAccountId { get; set; }
    }
}
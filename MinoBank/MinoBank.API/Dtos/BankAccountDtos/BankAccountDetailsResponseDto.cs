namespace MinoBank.API.Dtos.BankAccountDtos
{
    public class BankAccountDetailsResponseDto
    {
        public string BankName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public Guid BankAccountId { get; set; }
    }
}
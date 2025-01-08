using System.ComponentModel.DataAnnotations;

namespace MinoBank.API.Dtos.BankTransactionDtos
{
    public class BankTransactionCreateRequestDto
    {
        [Required]
        public Guid RecipientBankCardId { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }
    }
}
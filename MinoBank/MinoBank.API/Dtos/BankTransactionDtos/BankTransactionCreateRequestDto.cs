using System.ComponentModel.DataAnnotations;
using MinoBank.Core.Enums.BankTransaction;

namespace MinoBank.API.Dtos.BankTransactionDtos
{
    public class BankTransactionCreateRequestDto
    {
        [Required]
        public string SenderBankCardNumber { get; set; } = string.Empty;
        [Required]
        public string RecipientBankCardNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }
        public BankTransactionCurrencyCode CurrencyCode { get; set; }
    }
}
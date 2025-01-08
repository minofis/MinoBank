using System.ComponentModel.DataAnnotations;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.API.Dtos.BankCardDtos
{
    public class BankCardCreateRequestDto
    {
        [Required]
        public Guid BankAccountId { get; set; }
        [Required]
        public BankCardType Type { get; set; }
        [Required]
        public CurrencyCode CurrencyCode { get; set; }
    }
}
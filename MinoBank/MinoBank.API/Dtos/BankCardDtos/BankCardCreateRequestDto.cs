using System.ComponentModel.DataAnnotations;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.API.Dtos.BankCardDtos
{
    public class BankCardCreateRequestDto
    {
        [Required]
        public BankCardType Type { get; set; }
        [Required]
        public BankCardCurrencyCode CurrencyCode { get; set; }
    }
}
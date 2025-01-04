using MinoBank.Core.Enums.BankCard;

namespace MinoBank.API.Dtos.BankCardDtos
{
    public class BankCardCreateRequestDto
    {
        public BankCardType Type { get; set; }
    }
}
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.API.Dtos.BankAccountDtos
{
    public class BankAccountCreateRequestDto
    {
        public BankAccountType Type { get; set; }
        public string OwnerName { get; set; } = string.Empty;
    }
}
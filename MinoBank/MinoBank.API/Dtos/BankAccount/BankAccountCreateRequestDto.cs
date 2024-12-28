using MinoBank.Core.Enums.BankAccounts;

namespace MinoBank.API.Dtos
{
    public class BankAccountCreateRequestDto
    {
        public BankAccountType Type { get; set; }
        public string OwnerName { get; set; } = string.Empty;
    }
}
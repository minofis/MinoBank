using System.ComponentModel.DataAnnotations;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.API.Dtos.BankAccountDtos
{
    public class BankAccountCreateRequestDto
    {
        [Required]
        public BankAccountType Type { get; set; }
    }
}
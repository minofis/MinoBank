using MinoBank.Core.Entities.Identity;
using MinoBank.Core.Enums.BankAccount;

namespace MinoBank.Core.Entities
{
    public class BankAccount
    {
        public BankAccount(){}
        public BankAccount(Guid id, string userId, BankAccountDetails details, BankAccountType type, BankAccountStatus status, List<BankCard> bankCards)
        {
            Id = id;
            UserId = userId;
            Status = status;
            Type = type;
            BankCards = bankCards;
            Details = details;
        }

        public Guid Id { get; set; }
        public BankAccountStatus Status { get; private set; }
        public BankAccountType Type { get; private set; }
        public List<BankCard> BankCards { get; private set; }
        public BankAccountDetails Details { get; private set; }
        public string UserId { get; private set; }

        public static BankAccount Create(UserEntity user, BankAccountType type)
        {
            var details = BankAccountDetails.Create(Guid.NewGuid(), user.FullName, "MinoBank", DateTime.UtcNow.ToUniversalTime());

            return new BankAccount(details.BankAccountId, user.Id, details, type, BankAccountStatus.Active, []);
        }
    }
}
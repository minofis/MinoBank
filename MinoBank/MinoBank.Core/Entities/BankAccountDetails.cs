namespace MinoBank.Core.Entities
{
    public class BankAccountDetails
    {
        public BankAccountDetails(Guid bankAccountId, string ownerName, string bankName, DateTime creationDate)
        {
            BankAccountId = bankAccountId;
            OwnerName = ownerName;
            BankName = bankName;
            CreationDate = creationDate;
        }
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; private set; }
        public string BankName { get; private set; }
        public string OwnerName { get; private set; } 
        public DateTime CreationDate { get; private set; }

        public static BankAccountDetails Create(Guid bankAccountId, string ownerName, string bankName, DateTime creationDate)
        {
            return new BankAccountDetails(bankAccountId, ownerName, bankName, creationDate);
        }
    }
}
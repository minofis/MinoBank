namespace MinoBank.Core.Entities
{
    public class BankAccountDetails : BaseEntity
    {
        public string OwnerName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
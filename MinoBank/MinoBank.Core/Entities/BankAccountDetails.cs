namespace MinoBank.Core.Entities
{
    public class BankAccountDetails
    {
        public Guid BankAccountId { get; set; }
        public string BankName { get; set; } = "MinoBank";
        public string OwnerName { get; set; } = string.Empty;        
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public BankAccount? BankAccount { get; set; }
    }
}
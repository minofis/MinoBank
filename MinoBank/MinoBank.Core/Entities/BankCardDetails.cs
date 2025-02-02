using System.Text;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Entities
{
    public class BankCardDetails
    {
        public BankCardDetails(){}
        public BankCardDetails(Guid id, CurrencyCode currencyCode, string ownerName, DateTime creationDate, string number, string cvvCode, string expiryDate)
        {
            BankCardId = id;
            CurrencyCode = currencyCode;
            Number = number;
            CvvCode = cvvCode;
            ExpiryDate = expiryDate;
            OwnerName = ownerName;
            CreationDate = creationDate;
        }
        public Guid BankCardId { get; set; }
        public BankCard BankCard { get; set; }
        public CurrencyCode CurrencyCode { get; private set; }
        public string Number { get; private set; }
        public string CvvCode { get; private set; }
        public string ExpiryDate { get; private set; } 
        public string OwnerName { get; private set; }
        public DateTime CreationDate { get; private set; }

        public static BankCardDetails Create(Guid id, CurrencyCode currencyCode, string ownerName, DateTime creationDate)
        {
            return new BankCardDetails(id, currencyCode, ownerName, creationDate, GenerateRandomCardNumber(), GenerateRandomCvvCode(), "10/29");
        }

        private static string GenerateRandomCardNumber()
        {
            Random random = new Random();
            StringBuilder cardNumberBuilder = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                int randomDigit = random.Next(0, 10);
                cardNumberBuilder.Append(randomDigit);
            }
            return cardNumberBuilder.ToString();
        }
        private static string GenerateRandomCvvCode()
        {
            Random random = new Random();
            StringBuilder cardCvvCodeBuilder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                int randomDigit = random.Next(0, 10);
                cardCvvCodeBuilder.Append(randomDigit);
            }
            return cardCvvCodeBuilder.ToString();
        }
    }
}
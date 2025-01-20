using System.Text;
using MinoBank.Core.Enums.BankCard;

namespace MinoBank.Core.Entities
{
    public class BankCardDetails
    {
        public BankCardDetails()
        {
            Number = GenerateRandomCardNumber();
            CvvCode = GenerateRandomCvvCode();
        }
        public Guid BankCardId { get; set; }
        public BankCard BankCard { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string Number { get; set; } = string.Empty;
        public string CvvCode { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = "10/29";
        public string OwnerName { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now.ToUniversalTime();

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
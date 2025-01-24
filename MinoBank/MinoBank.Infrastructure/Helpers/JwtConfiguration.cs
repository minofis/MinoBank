namespace MinoBank.Infrastructure.Helpers
{
    public class JwtConfiguration
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiresHours { get; set; }
    }
}
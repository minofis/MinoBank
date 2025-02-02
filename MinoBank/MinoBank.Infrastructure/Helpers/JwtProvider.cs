using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Auth;

namespace MinoBank.Infrastructure.Helpers
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtConfiguration _configuration;
        public JwtProvider(IOptions<JwtConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }
        public string GenerateToken(UserEntity user)
        {
            var claims = new []
            {
                new Claim("userId", user.Id.ToString())
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.SecretKey));

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_configuration.ExpiresHours)
            );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
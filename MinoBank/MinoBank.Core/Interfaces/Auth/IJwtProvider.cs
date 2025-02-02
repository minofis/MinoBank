using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(UserEntity user);
    }
}
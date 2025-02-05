using MinoBank.Core.Entities.Identity;

namespace MinoBank.Core.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(UserEntity user, IList<string> roles);
    }
}
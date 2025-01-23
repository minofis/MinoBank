using MinoBank.Core.Entities;

namespace MinoBank.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task Register(string firstName, string lastName, int age, string phoneNumber, string email, string password);
    }
}
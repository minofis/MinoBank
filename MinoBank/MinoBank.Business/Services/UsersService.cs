using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Auth;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepo;
        private readonly IPasswordHasher _passowordHasher;
        public UsersService(IUsersRepository usersRepo, IPasswordHasher passowordHasher)
        {
            _usersRepo = usersRepo;
            _passowordHasher = passowordHasher;
        }

        public async Task Register(string firstName, string lastName, int age, string phoneNumber, string email, string password)
        {
            var hashedPassword = _passowordHasher.Generate(password); 

            var user = User.Create(Guid.NewGuid(), firstName, lastName, age, phoneNumber, email, hashedPassword);

            await _usersRepo.AddUserAsync(user);
        }
    }
}
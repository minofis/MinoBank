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
        private readonly IJwtProvider _jwtProvider;
        public UsersService(IUsersRepository usersRepo, IPasswordHasher passowordHasher, IJwtProvider jwtProvider)
        {
            _usersRepo = usersRepo;
            _passowordHasher = passowordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string phoneNumber, string password)
        {
            var user =  await _usersRepo.GetUserByPhoneNumberAsync(phoneNumber) 
                ?? throw new ArgumentException($"User with phone number {phoneNumber} not found.");

            var result = _passowordHasher.Verify(user.PasswordHash, password);

            if(result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

        public async Task Register(string firstName, string lastName, int age, string phoneNumber, string email, string password)
        {
            var hashedPassword = _passowordHasher.Generate(password); 

            var user = User.Create(Guid.NewGuid(), firstName, lastName, age, phoneNumber, email, hashedPassword);

            await _usersRepo.AddUserAsync(user);
        }
    }
}
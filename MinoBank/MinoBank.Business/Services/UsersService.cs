using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Auth;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Core.Interfaces.Services;

namespace MinoBank.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepo;
        private readonly IRolesRepository _rolesRepo;
        private readonly IPasswordHasher _passowordHasher;
        private readonly IJwtProvider _jwtProvider;
        public UsersService(IUsersRepository usersRepo, IPasswordHasher passowordHasher, IJwtProvider jwtProvider, IRolesRepository rolesRepo)
        {
            _usersRepo = usersRepo;
            _passowordHasher = passowordHasher;
            _jwtProvider = jwtProvider;
            _rolesRepo = rolesRepo;
        }

        public async Task<string> Login(string phoneNumber, string password)
        {
            // Get user by phone number
            var user = await _usersRepo.GetUserByPhoneNumberAsync(phoneNumber) 
                ?? throw new ArgumentException($"User with phone number {phoneNumber} not found.");

            // Verify that password is correct
            var result = _passowordHasher.Verify(user.PasswordHash, password);

            // Validate password
            if(result == false)
            {
                throw new Exception("Failed to login");
            }

            // Generate jwt token for the user
            var token = _jwtProvider.GenerateToken(user);

            // Return token
            return token;
        }

        public async Task Register(string firstName, string lastName, int age, string phoneNumber, string email, string password)
        {
            if(await _usersRepo.GetUserByPhoneNumberAsync(phoneNumber) != null)
            {
                throw new ArgumentException($"User with phone number {phoneNumber} alredy exist");
            }

            if(await _usersRepo.GetUserByEmailAsync(email) != null)
            {
                throw new ArgumentException($"User with email {email} alredy exist");
            }

            var hashedPassword = _passowordHasher.Generate(password);

            var user = UserEntity.Create(Guid.NewGuid(), firstName, lastName, age, phoneNumber, email, hashedPassword);

            await _usersRepo.AddUserAsync(user);
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid userId)
        {
            return await _usersRepo.GetUserByIdAsync(userId)
                ?? throw new ArgumentException($"User with ID {userId} not found.");;
        }

        public async Task AddRoleToUserAsync(Guid userId, string roleName)
        {
            var role = await _rolesRepo.GetRoleByNameAsync(roleName)
                ?? throw new ArgumentException($"Role with name {roleName} not found.");

            await _usersRepo.AddRoleToUserAsync(userId, role);
        }

        public async Task RemoveRoleFromUserAsync(Guid userId, string roleName)
        {
            await _usersRepo.RemoveRoleFromUserAsync(userId, roleName);
        }
    }
}
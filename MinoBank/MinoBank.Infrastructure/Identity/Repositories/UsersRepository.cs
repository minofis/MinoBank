using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinoBank.Core.Entities;
using MinoBank.Core.Interfaces.Repositories;
using MinoBank.Infrastructure.Identity.Entities;

namespace MinoBank.Infrastructure.Identity.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserIdentityDbContext _context;
        private readonly IMapper _mapper;
        public UsersRepository(UserIdentityDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
            
            return _mapper.Map<User>(userEntity);
        }
        public async Task AddUserAsync(User user)
        {
            var userEntity = new UserEntity(){
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
    }
}
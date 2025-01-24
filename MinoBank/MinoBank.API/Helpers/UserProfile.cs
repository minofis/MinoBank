using AutoMapper;
using MinoBank.API.Dtos.UserDtos;
using MinoBank.Core.Entities;
using MinoBank.Infrastructure.Identity.Entities;

namespace MinoBank.API.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();

            CreateMap<UserEntity, User>();
        }
    }
}
using AutoMapper;
using MinoBank.API.Dtos.UserDtos;
using MinoBank.Core.Entities.Identity;

namespace MinoBank.API.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserResponseDto>();
            
            CreateMap<RoleEntity, RoleResponseDto>();
        }
    }
}
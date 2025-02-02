using AutoMapper;
using MinoBank.API.Dtos.UserDtos;
using MinoBank.Core.Entities;

namespace MinoBank.API.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserResponseDto>()
                .ForMember(t => t.Roles, o => o.MapFrom(s => s.Roles));
        }
    }
}
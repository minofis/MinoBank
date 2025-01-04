using AutoMapper;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.Core.Entities;

namespace MinoBank.API.Helpers
{
    public class BankCardProfile : Profile
    {
        public BankCardProfile()
        {
            CreateMap<BankCardCreateRequestDto, BankCard>()
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()));
        }
    }
}
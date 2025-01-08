using AutoMapper;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.Core.Entities;

namespace MinoBank.API.Helpers
{
    public class BankCardProfile : Profile
    {
        public BankCardProfile()
        {
            CreateMap<BankCard, BankCardResponseDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()));

            CreateMap<BankCardDetails, BankCardDetailsResponseDto>()
                .ForMember(d => d.CurrencyCode, o => o.MapFrom(s => s.CurrencyCode.ToString()))
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreationDate.ToString()));

            CreateMap<BankCardCreateRequestDto, BankCard>()
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()));
        }
    }
}
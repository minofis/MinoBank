using AutoMapper;
using MinoBank.API.Dtos.BankAccountDtos;
using MinoBank.API.Dtos.BankCardDtos;
using MinoBank.Core.Entities;

namespace MinoBank.API.Helpers
{
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountResponseDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()));
            
            CreateMap<BankAccountDetails, BankAccountDetailsResponseDto>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreationDate.ToString()));
        }
    }
}
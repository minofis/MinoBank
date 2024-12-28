using AutoMapper;
using MinoBank.API.Dtos;
using MinoBank.API.Dtos.BankAccount;
using MinoBank.API.Dtos.BankAccountDetails;
using MinoBank.Core.Entities;

namespace MinoBank.API.Helpers
{
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountResponseDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.Details, o => o.MapFrom(s => new BankAccountDetailsResponseDto
                {
                    BankName = s.Details.BankName,
                    OwnerName = s.Details.OwnerName,
                    CreationDate = s.Details.CreationDate,
                    BankAccountId = s.Details.BankAccountId
                }))
                .ForMember(d => d.BankCards, o => o.MapFrom(s => s.BankCards));
            
            CreateMap<BankAccountDetails, BankAccountDetailsResponseDto>();

            CreateMap<BankAccountCreateRequestDto, BankAccount>()
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                .ForMember(d => d.Details, o => o.MapFrom(s => new BankAccountDetails
                {
                    OwnerName = s.OwnerName
                }));
        }
    }
}
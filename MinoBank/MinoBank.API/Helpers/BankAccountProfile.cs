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
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.Details, o => o.MapFrom(s => s.Details))
                .ForMember(d => d.BankCards, o => o.MapFrom(s => s.BankCards));
            
            CreateMap<BankAccountDetails, BankAccountDetailsResponseDto>()
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreationDate.ToString()));

            CreateMap<BankCard, BankCardResponseDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.SentTransactions, o => o.MapFrom(s => s.SentTransactions))
                .ForMember(d => d.RecivedTransactions, o => o.MapFrom(s => s.RecivedTransactions))
                .ForMember(d => d.Details, o => o.MapFrom(s => s.Details));

            CreateMap<BankCardDetails, BankCardDetailsResponseDto>()
                .ForMember(d => d.CurrencyCode, o => o.MapFrom(s => s.CurrencyCode.ToString()))
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreationDate.ToString()));

            CreateMap<BankAccountCreateRequestDto, BankAccount>()
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type))
                .ForMember(d => d.Details, o => o.MapFrom(s => new BankAccountDetails
                {
                    OwnerName = s.OwnerName
                }));
        }
    }
}
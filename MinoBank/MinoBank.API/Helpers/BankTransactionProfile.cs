using AutoMapper;
using MinoBank.API.Dtos.BankTransactionDtos;
using MinoBank.Core.Entities;

namespace MinoBank.API.Helpers
{
    public class BankTransactionProfile : Profile
    {
        public BankTransactionProfile()
        {
            CreateMap<BankTransaction, BankTransactionResponseDto>()
                .ForMember(t => t.Category, o => o.MapFrom(s => s.Category.ToString()))
                .ForMember(t => t.CurrencyCode, o => o.MapFrom(s => s.CurrencyCode.ToString()));
            
            CreateMap<BankTransactionCreateRequestDto, BankTransaction>();
        }
    }
}
using AutoMapper;
using ContaVirtual_AM.Application.v1.Accounts;
using ContaVirtual_AM.Controllers.v1.Transactions.ViewModels;
using ContaVirtual_AM.Domain.v1.Accounts;
using ContaVirtual_AM.Domain.v1.Transactions;

namespace ContaVirtual_AM.ApiSettings.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountCreate.Command, Account>();
            CreateMap<AccountTransaction, TransactionViewModel>();
        }
    }
}

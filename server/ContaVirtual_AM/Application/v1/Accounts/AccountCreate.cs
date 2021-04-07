using AutoMapper;
using ContaVirtual_AM.Domain.v1.Accounts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Application.v1.Accounts
{
    public class AccountCreate
    {
        public class Command : IRequest<Guid>
        {
            public string Customer { get; set; }
            public string CPF { get; set; }   
            public string Phone { get; set; }
        }

        public class Handler : IRequestHandler<Command, Guid>
        {
            private IAccountRepository _accountRepository;
            private readonly IMapper _mapper;  

            public Handler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;              
                _mapper = mapper;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var account = _mapper.Map<Account>(request);
                account.SetOpeningDate(DateTime.Now); 
               
                var response = await _accountRepository.Add(account);

                return response;
            }
        }
    }
}

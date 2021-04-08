using AutoMapper;
using ContaVirtual_AM.Controllers.v1.Transactions.ViewModels;
using ContaVirtual_AM.Domain.v1.Accounts;
using ContaVirtual_AM.Domain.v1.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Application.v1.Transactions
{
    public class TransactionCollection
    {
        public class Query : IRequest<StatementViewModel>
        {
            public string CPF { get; set; }

            public Query(string cpf)
            {
                CPF = cpf;
            }
        }

        public class Handler : IRequestHandler<Query, StatementViewModel>
        {
            private IAccountRepository _accountRepository;
            private IAccountTransactionRepository _accountTransactionRepository;
            private IMapper _mapper;

            public Handler(IAccountRepository accountRepository, IAccountTransactionRepository accountTransactionRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _accountTransactionRepository = accountTransactionRepository;
                _mapper = mapper;
            }

            public async Task<StatementViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var account = await _accountRepository.GetByCPF(request.CPF);

                if (account is null)
                {
                    throw new Exception($"Não existe a conta virtual com CPF '{request.CPF}'.");
                }

                var transactions = _accountTransactionRepository.GetTransactionsById(account.Id);

                var statement = new StatementViewModel(account.Customer, account.Balance);

                var statementTransactions = _mapper.Map<List<TransactionViewModel>>(transactions);
                statement.SetTransactions(statementTransactions);

                return statement;
            }
        }
    }
}

using ContaVirtual_AM.Domain.v1.Accounts;
using ContaVirtual_AM.Domain.v1.Transactions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Application.v1.Transactions
{
    public class AccountDebit
    {
        public class Command : IRequest<bool>
        {
            public string CPF { get; set; }
            public string Description { get; set; }
            public double Value { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private IAccountRepository _accountRepository;
            private IAccountTransactionRepository _accountTransactionRepository;

            public Handler(IAccountRepository accountRepository, IAccountTransactionRepository accountTransactionRepository)
            {
                _accountRepository = accountRepository;
                _accountTransactionRepository = accountTransactionRepository;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var account = await _accountRepository.GetByCPF(request.CPF);

                if (account is null)
                    throw new Exception($"Não existe a conta virtual com CPF '{request.CPF}'.");

                var result = account.Debit(request.Value);

                if (result)
                {
                    var transaction = new AccountTransaction(account.Id, request.Description, TransactionType.Debit, request.Value);

                    _ = await _accountTransactionRepository.Add(transaction);
                    _ = _accountRepository.Update(account);
                }

                return result;
            }
        }
    }
}

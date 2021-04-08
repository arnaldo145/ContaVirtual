using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Domain.v1.Transactions
{
    public interface IAccountTransactionRepository
    {
        Task<Guid> Add(AccountTransaction transaction);
        ICollection<AccountTransaction> GetTransactionsById(Guid accountId);
    }
}

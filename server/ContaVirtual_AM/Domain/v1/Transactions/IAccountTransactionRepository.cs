using System;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Domain.v1.Transactions
{
    public interface IAccountTransactionRepository
    {
        Task<Guid> Add(AccountTransaction transaction);
    }
}

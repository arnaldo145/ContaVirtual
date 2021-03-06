using System;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Domain.v1.Accounts
{
    public interface IAccountRepository
    {
        Task<Guid> Add(Account account);
        Task<Account> GetByCPF(string cpf);
        Task Update(Account account);
    }
}

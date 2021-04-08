using ContaVirtual_AM.Context;
using ContaVirtual_AM.Domain.v1.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Repository.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly VirtualAccountDbContext _context;

        public AccountRepository(VirtualAccountDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Account account)
        {
            account = _context.Accounts.Add(account).Entity;
            await _context.SaveChangesAsync();

            return account.Id;
        }

        public async Task<Account> GetByCPF(string cpf)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.CPF == cpf);
            return account;
        }

        public async Task Update(Account account)
        {
             _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}

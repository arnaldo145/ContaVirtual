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

        public Task<Account> GetById(Guid id)
        {
            var account = _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);

            return account;
        }
    }
}

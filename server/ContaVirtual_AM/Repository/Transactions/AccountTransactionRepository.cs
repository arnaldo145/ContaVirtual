using ContaVirtual_AM.Context;
using ContaVirtual_AM.Domain.v1.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaVirtual_AM.Repository.Transactions
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly VirtualAccountDbContext _context;

        public AccountTransactionRepository(VirtualAccountDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(AccountTransaction transaction)
        {
            transaction = _context.Transactions.Add(transaction).Entity;
            await _context.SaveChangesAsync();

            return transaction.Id;
        }

        public ICollection<AccountTransaction> GetTransactionsById(Guid accountId)
        {
            var result = _context.Transactions.Where(x => x.AccountId == accountId);
            return result.ToList();
        }
    }
}

using ContaVirtual_AM.Domain.v1.Accounts;
using System;

namespace ContaVirtual_AM.Domain.v1.Transactions
{
    public class AccountTransaction
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public TransactionType Type { get; set; }

        public AccountTransaction(Guid accountId, string description, TransactionType type, double value)
        {
            AccountId = accountId;
            Description = description;
            Type = type;
            Value = value;
            Date = DateTime.Now;
        }
    }
}

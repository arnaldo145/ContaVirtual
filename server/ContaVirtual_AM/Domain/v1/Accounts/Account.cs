using ContaVirtual_AM.Domain.v1.Transactions;
using System;
using System.Collections.Generic;

namespace ContaVirtual_AM.Domain.v1.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public DateTime OpeningDate { get; set; }
        public double Balance { get; set; }
        public List<AccountTransaction> Transactions { get; set; }

        public void SetOpeningDate(DateTime openingDate)
        {
            OpeningDate = openingDate;
        }

        public bool Debit(double value)
        {
            if (value > Balance || value <= 0)
                return false;            

            Balance -= value;
            return true;
        }

        public bool Credit(double value)
        {
            if (value <= 0)
                return false;

            Balance += value;
            return true;
        }
    }
}
using System;

namespace ContaVirtual_AM.Domain.v1.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public string CPF { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal Balance { get; set; }

        public void SetOpeningDate(DateTime openingDate)
        {
            OpeningDate = openingDate;
        }
    }
}
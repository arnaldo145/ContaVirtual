using System.Collections.Generic;

namespace ContaVirtual_AM.Controllers.v1.Transactions.ViewModels
{
    public class StatementViewModel
    {
        public string Customer { get; set; }
        public ICollection<TransactionViewModel> Transactions { get; set; }
        public double Balance { get; set; }

        public StatementViewModel(string customer, double balance)
        {
            Customer = customer;
            Balance = balance;
            Transactions = new List<TransactionViewModel>();
        }

        public void SetTransactions(ICollection<TransactionViewModel> transactions)
        {
            Transactions = transactions;
        }
    }
}

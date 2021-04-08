using System;

namespace ContaVirtual_AM.Controllers.v1.Transactions.ViewModels
{
    public class TransactionViewModel
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}

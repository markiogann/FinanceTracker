using System;

namespace FinanceTracker.Classes.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TransactionType Type { get; set; } = TransactionType.Expense;
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; } = "";
    }
}

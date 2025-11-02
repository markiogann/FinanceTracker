using System;
using FinanceTracker.Classes.Models;

namespace FinanceTracker.Classes.Reporting
{
    public class TransactionReportRow
    {
        public DateTime Date;
        public TransactionType Type;
        public string CategoryName;
        public decimal Amount;
        public string Comment;
    }
}

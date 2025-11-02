using System;
using System.Collections.Generic;

namespace FinanceTracker.Classes.Models
{
    public class BudgetLimit
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;
        public bool AppliesToAll { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;

namespace FinanceTracker.Classes.Services
{
    public class BudgetService
    {
        private readonly BudgetRepository _budRepo = new BudgetRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();
        private readonly TransactionRepository _txRepo = new TransactionRepository();

        public class CheckResult
        {
            public bool IsExceeded;
            public decimal TotalExceededBy;
            public string Message;
        }

        public CheckResult CheckExceedForExpense(int categoryId, decimal newAmount, DateTime newDate, Transaction originalTx)
        {
            var res = new CheckResult { IsExceeded = false, TotalExceededBy = 0m, Message = "" };

            var active = _budRepo.GetActive(newDate);
            if (active.Count == 0) return res;

            var allCategories = _catRepo.GetAll(includeDeleted: false).Select(c => c.Id).ToList();

            Func<BudgetLimit, List<int>> scope = b => b.AppliesToAll ? allCategories : (b.CategoryIds ?? new List<int>());

            var affected = active.Where(b => scope(b).Contains(categoryId)).ToList();
            if (affected.Count == 0) return res;

            var sb = new StringBuilder();
            sb.AppendLine("Будет превышен лимит:");

            foreach (var b in affected)
            {
                var cats = scope(b);

                decimal spent = _txRepo.SumExpensesByCategoriesAndPeriod(cats, b.StartDate, b.EndDate);

                if (originalTx != null && originalTx.Type == TransactionType.Expense)
                {
                    bool samePeriod = originalTx.Date >= b.StartDate && originalTx.Date <= b.EndDate;
                    bool inScope = cats.Contains(originalTx.CategoryId);
                    if (samePeriod && inScope)
                        spent -= originalTx.Amount;
                    if (spent < 0) spent = 0;
                }

                var prospective = spent + newAmount;
                if (prospective > b.Amount)
                {
                    var exceed = prospective - b.Amount;
                    res.IsExceeded = true;
                    res.TotalExceededBy += exceed;

                    string scopeText;
                    if (b.AppliesToAll)
                    {
                        scopeText = "Все категории";
                    }
                    else
                    {
                        var names = _catRepo.GetAll(false)
                            .Where(c => b.CategoryIds.Contains(c.Id))
                            .Select(c => c.Name)
                            .ToList();
                        scopeText = string.Join(", ", names);
                    }

                    sb.AppendLine($"• Период {b.StartDate:dd.MM.yyyy}–{b.EndDate:dd.MM.yyyy}, категории: {scopeText}, лимит {b.Amount:0.##}, превышение на {exceed:0.##}");
                }
            }

            if (res.IsExceeded)
                res.Message = sb.ToString().Trim();
            return res;
        }
    }
}

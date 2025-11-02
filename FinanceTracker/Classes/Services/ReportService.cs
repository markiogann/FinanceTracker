using System;
using System.Collections.Generic;
using System.Linq;
using FinanceTracker.Classes.Models;
using FinanceTracker.Classes.Repositories;
using FinanceTracker.Classes.Reporting;

namespace FinanceTracker.Classes.Services
{
    public class ReportService
    {
        private readonly TransactionRepository _txRepo = new TransactionRepository();
        private readonly CategoryRepository _catRepo = new CategoryRepository();

        public class ReportParams
        {
            public DateTime Start;
            public DateTime End;
            public int? TypeFilter;
            public List<int> CategoryIds;
            public decimal? MinAmount;
            public decimal? MaxAmount;
        }

        public List<TransactionReportRow> BuildRows(ReportParams p)
        {
            var items = _txRepo.GetForReportWithCategoryName(
                p.Start, p.End, p.TypeFilter,
                (p.CategoryIds == null || p.CategoryIds.Count == 0) ? null : p.CategoryIds,
                p.MinAmount, p.MaxAmount
            );

            var rows = new List<TransactionReportRow>();
            foreach (var pair in items)
            {
                var tx = pair.tx;
                rows.Add(new TransactionReportRow
                {
                    Date = tx.Date,
                    Type = tx.Type,
                    CategoryName = pair.categoryName,
                    Amount = tx.Amount,
                    Comment = tx.Comment
                });
            }
            return rows;
        }

        public void GeneratePdf(string filePath, ReportParams p)
        {
            var rows = BuildRows(p);

            List<string> catNames = null;
            if (p.CategoryIds != null && p.CategoryIds.Count > 0)
            {
                var all = _catRepo.GetAll(false);
                catNames = new List<string>();
                foreach (var id in p.CategoryIds)
                {
                    var found = all.FirstOrDefault(c => c.Id == id);
                    if (found != null) catNames.Add(found.Name);
                }
            }

            PdfReportBuilder.Build(
                filePath,
                p.Start, p.End,
                p.TypeFilter,
                catNames,
                p.MinAmount, p.MaxAmount,
                rows
            );
        }
    }
}

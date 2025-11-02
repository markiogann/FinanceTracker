using System;
using System.Collections.Generic;
using System.Globalization;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using FinanceTracker.Classes.Models;

namespace FinanceTracker.Classes.Reporting
{
    public static class PdfReportBuilder
    {
        private static IContainer HeaderCell(IContainer c)
        {
            return c.DefaultTextStyle(x => x.SemiBold())
                    .Padding(4)
                    .Background(Colors.Grey.Lighten3);
        }

        private static IContainer RowCell(IContainer c)
        {
            return c.Padding(4)
                    .BorderBottom(1)
                    .BorderColor(Colors.Grey.Lighten3);
        }

        private static IContainer FooterCell(IContainer c)
        {
            return c.Padding(6)
                    .Background(Colors.Grey.Lighten4)
                    .DefaultTextStyle(x => x.SemiBold());
        }

        public static void Build(
            string filePath,
            DateTime start, DateTime end,
            int? typeFilter,
            List<string> categoriesCaption,
            decimal? minAmount, decimal? maxAmount,
            List<TransactionReportRow> rows
        )
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var culture = CultureInfo.GetCultureInfo("ru-RU");

            var doc = Document.Create(pg =>
            {
                pg.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Row(r =>
                    {
                        r.RelativeItem().Column(col =>
                        {
                            col.Item().Text("FinanceTracker — Отчёт по операциям").SemiBold().FontSize(14);
                            col.Item().Text(string.Format("Период: {0:dd.MM.yyyy} — {1:dd.MM.yyyy}", start, end));
                            col.Item().Text("Тип: " + (typeFilter == null ? "Все" : (typeFilter == 1 ? "Доход" : "Расход")));
                            col.Item().Text("Категории: " + ((categoriesCaption == null || categoriesCaption.Count == 0) ? "Все" : string.Join(", ", categoriesCaption)));
                            col.Item().Text("Сумма: " + (minAmount != null ? (">= " + minAmount.Value.ToString("0.##")) : "—")
                                + " ... " + (maxAmount != null ? ("<= " + maxAmount.Value.ToString("0.##")) : "—"));
                        });
                        r.ConstantItem(120).AlignRight().Column(col =>
                        {
                            col.Item().Text(DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                            col.Item().Text("v1.0").FontColor(Colors.Grey.Darken2);
                        });
                    });

                    page.Content().Column(col =>
                    {
                        col.Spacing(8);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(5);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderCell).Text("Дата");
                                header.Cell().Element(HeaderCell).Text("Тип");
                                header.Cell().Element(HeaderCell).Text("Категория");
                                header.Cell().Element(HeaderCell).Text("Сумма");
                                header.Cell().Element(HeaderCell).Text("Комментарий");
                            });

                            decimal totalIncome = 0m;
                            decimal totalExpense = 0m;

                            foreach (var r in rows)
                            {
                                table.Cell().Element(RowCell).Text(r.Date.ToString("dd.MM.yyyy HH:mm"));
                                table.Cell().Element(RowCell).Text(r.Type == TransactionType.Income ? "Доход" : "Расход");
                                table.Cell().Element(RowCell).Text(r.CategoryName);
                                table.Cell().Element(RowCell).Text(r.Amount.ToString("0.##", culture)).AlignRight();
                                table.Cell().Element(RowCell).Text(string.IsNullOrEmpty(r.Comment) ? "" : r.Comment);

                                if (r.Type == TransactionType.Income) totalIncome += r.Amount;
                                else totalExpense += r.Amount;
                            }

                            table.Cell().ColumnSpan(3).Element(FooterCell).Text("Итого:");
                            table.Cell().Element(FooterCell).Text(string.Format("Доходы: {0:0.##}", totalIncome)).AlignRight();
                            table.Cell().Element(FooterCell).Text(string.Format("Расходы: {0:0.##}", totalExpense));
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("FinanceTracker • ").FontColor(Colors.Grey.Darken2);
                        x.Span("Автоотчёт PDF").FontColor(Colors.Grey.Darken2);
                    });
                });
            });

            doc.GeneratePdf(filePath);
        }
    }
}

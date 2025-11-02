using System;
using System.Globalization;

namespace FinanceTracker.Classes.Utils
{
    public static class MoneyUtils
    {
        public static string Format(decimal amount)
            => amount.ToString("0.##", CultureInfo.InvariantCulture);

        public static decimal ParseOrThrow(string input, string fieldName)
        {
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
                return value;
            throw new FormatException($"Поле «{fieldName}» должно быть числом.");
        }
    }
}

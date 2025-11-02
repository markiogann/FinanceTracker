using System;
using System.Globalization;

namespace FinanceTracker.Classes.Utils
{
    public static class DateUtils
    {
        private const string IsoFormat = "yyyy-MM-dd HH:mm:ss";

        public static string ToIsoString(this DateTime dt)
            => dt.ToString(IsoFormat, CultureInfo.InvariantCulture);

        public static DateTime FromIsoString(string s)
            => DateTime.ParseExact(s, IsoFormat, CultureInfo.InvariantCulture);

        public static DateTime StartOfDay(DateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        public static DateTime EndOfDay(DateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);

        public static (DateTime start, DateTime end) TodayRange()
            => (StartOfDay(DateTime.Today), EndOfDay(DateTime.Today));
    }
}

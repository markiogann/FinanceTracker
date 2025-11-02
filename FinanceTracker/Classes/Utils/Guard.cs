using System;

namespace FinanceTracker.Classes.Utils
{
    public static class Guard
    {
        public static void NotNull(object obj, string name)
        {
            if (obj == null) throw new ArgumentNullException(name);
        }

        public static void NotNullOrWhiteSpace(string s, string name)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException(name + " не может быть пустым.");
        }

        public static void GreaterThanZero(decimal value, string name)
        {
            if (value <= 0) throw new ArgumentException(name + " должно быть > 0.");
        }
    }
}

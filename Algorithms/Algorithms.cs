using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static ulong GetFactorial(int n)
        {
            if (n < 0 || n > 20)
                throw new ArgumentOutOfRangeException(nameof(n));
            if (n <= 1)
                return 1;

            ulong factorial = (ulong)n;
            for (int i = 2; i < n; factorial *= (ulong)i, i++) ;
            return factorial;

            //Recursion, but why waste the stack space on simple math?
            //return (ulong)n * GetFactorial(n - 1);
        }

        public static string FormatSeparators(bool useOxfordComma, params string[] items)
        {
            if (items == null || items.Length == 0)
                return string.Empty; // Maybe argument null/outofrange exception instead?
            if (items.Length == 1)
                return items[0];

            return $"{string.Join(", ", items[0..^1])}{(useOxfordComma && items.Length > 2 ? "," : string.Empty)} and {items[^1]}";
        }
    }
}
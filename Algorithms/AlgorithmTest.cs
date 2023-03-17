using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(4, 24)]
        [InlineData(10, 3628800)]
        [InlineData(20, 2432902008176640000)]
        public void CanGetFactorial(int n, ulong expectedResult)
        {
            Assert.Equal(expectedResult, Algorithms.GetFactorial(n));
        }

        [Theory]
        [InlineData(false, null, "")]
        [InlineData(false, new string[] { "one" }, "one")]
        [InlineData(false, new string[] { "one", "two" }, "one and two")]
        [InlineData(false, new string[] { "a", "b", "c" }, "a, b and c")]
        [InlineData(false, new string[] { "a", "b", "c", "d", "e", "f" }, "a, b, c, d, e and f")]
        [InlineData(true, new string[] { "one", "two" }, "one and two")]
        [InlineData(true, new string[] { "a", "b", "c" }, "a, b, and c")]
        [InlineData(true, new string[] { "a", "b", "c", "d", "e", "f" }, "a, b, c, d, e, and f")]
        public void CanFormatSeparators(bool useOxfordComma, string[] items, string expectedResult)
        {
            Assert.Equal(expectedResult, Algorithms.FormatSeparators(useOxfordComma, items));
        }
    }
}
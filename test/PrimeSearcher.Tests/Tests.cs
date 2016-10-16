using System;
using Xunit;
using Primes;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void TestFirstPrimes() 
        {
            var list = PrimeSearcher.Sieve(200);
            var truePrimes = new int[] {
                2, 3, 5, 7, 11, 13, 17, 
                19, 23, 29, 31, 37, 41, 
                43, 47, 53, 59, 61, 67, 
                71, 73, 79, 83, 89, 97, 
                101, 103, 107, 109, 113, 
                127, 131, 137, 139, 149, 
                151, 157, 163, 167, 173, 
                179, 181, 191, 193, 197, 199
            };
            for (int i = 0; i < list.Count; i++) 
            {
                Assert.True(list[i] == truePrimes[i], $"{i} position prime must be {truePrimes[i]}. Actual: {list[i]}");
            }
        }

        [Fact]
        public void TestPrimesCount()
        {
            var list = PrimeSearcher.Sieve(100000);
            var trueCount = 9592;
            Assert.True(list.Count == trueCount, $"Primes count before 100000 is {trueCount}. Actual: {list.Count}");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        [InlineData(0)]
        public void TestNegativeParameter(int arg) 
        {
            var list = PrimeSearcher.Sieve(arg);
            Assert.True(list.Count == 0, $"Primes count with negative argument must be 0. Actual: {list.Count}");
        }
    }
}

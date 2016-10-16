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
            var sieveResult = PrimeSearcher.Sieve(200);
            var doubleSieveResult = PrimeSearcher.DoubleSieve(200);
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
            for (int i = 0; i < sieveResult.Count; i++) 
            {
                Assert.True(sieveResult[i] == truePrimes[i], $"{i} position prime must be {truePrimes[i]}. Actual: {sieveResult[i]}");
                Assert.True(doubleSieveResult[i] == truePrimes[i], $"{i} position prime must be {truePrimes[i]}. Actual: {doubleSieveResult[i]}");
            }
        }

        [Fact]
        public void TestPrimesCount()
        {
            var sieveResult = PrimeSearcher.Sieve(100000);
            var doubleSieveResult = PrimeSearcher.DoubleSieve(100000);
            var trueCount = 9592;
            Assert.True(sieveResult.Count == trueCount, $"Primes count before 100000 is {trueCount}. Actual: {sieveResult.Count}");
            Assert.True(doubleSieveResult.Count == trueCount, $"Primes count before 100000 is {trueCount}. Actual: {doubleSieveResult.Count}");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        [InlineData(0)]
        public void TestNegativeParameter(int arg) 
        {
            var sieveResult = PrimeSearcher.Sieve(arg);
            var doubleSieveResult = PrimeSearcher.DoubleSieve(arg);
            Assert.True(sieveResult.Count == 0, $"Primes count with negative argument must be 0. Actual: {sieveResult.Count}");
            Assert.True(doubleSieveResult.Count == 0, $"Primes count with negative argument must be 0. Actual: {doubleSieveResult.Count}");
        }
    }
}

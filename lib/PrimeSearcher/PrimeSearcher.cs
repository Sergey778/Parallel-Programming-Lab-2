using System;
using System.Collections.Generic;
using System.Collections;

namespace Primes
{
    public class PrimeSearcher
    {
        protected static Tuple<List<int>, BitArray> SieveImplementation(int highBound)
        {
            var result = new List<int>();
            if (highBound <= 1) return new Tuple<List<int>, BitArray>(result, new BitArray(0));
            var primes = new BitArray(highBound, true);
            for (int i = 2; i < highBound; i++)
            {
                long square = 1L * i * i;
                if (primes.Get(i))
                {
                    for (long j = square; j < highBound; j += i)
                    {
                        primes.Set((int) j, false);
                    }
                    result.Add(i);
                }
            }
            return new Tuple<List<int>, BitArray>(result, primes);
        }

        public static List<int> Sieve(int highBound) => SieveImplementation(highBound).Item1;

        public static List<int> DoubleSieve(int highBound) 
        {
            if (highBound <= 1) return new List<int>();
            var midBound = (int) Math.Sqrt(highBound);
            var sieveTuple = SieveImplementation((int)Math.Sqrt(highBound));
            var firstPrimes = sieveTuple.Item1;
            var primes = new BitArray(highBound - midBound, true);
            foreach (var prime in firstPrimes) 
            {
                var remainder = midBound % prime;
                for (int j = remainder == 0 ? 0 : prime - remainder; j < highBound - midBound; j += prime)
                {
                    primes.Set(j, false);
                }
            }
            for (int i = 0; i < primes.Length; i++) 
            {
                if (primes.Get(i))
                {
                    firstPrimes.Add(i + midBound);
                }
            }
            return firstPrimes;
        }
    }
}

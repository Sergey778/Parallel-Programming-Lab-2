using System;
using System.Collections.Generic;
using System.Collections;

namespace Primes
{
    public class PrimeSearcher
    {
        public static List<int> Sieve(int highBound)
        {
            var result = new List<int>();
            if (highBound <= 1) return result;
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
            return result;
        }
    }
}

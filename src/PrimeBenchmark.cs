using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

public class PrimeBenchmark 
{
    [Params(100, 1000, 100000, 500000)]
    public int Length { get; set; }

    [Benchmark]
    public List<int> SieveTest() 
    {
        return Primes.PrimeSearcher.Sieve(Length);
    }

    [Benchmark]
    public List<int> DoubleSieveTest()
    {
        return Primes.PrimeSearcher.DoubleSieve(Length);
    }
}
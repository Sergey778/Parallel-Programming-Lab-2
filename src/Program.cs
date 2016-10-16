using System;
using BenchmarkDotNet.Running;

class Program
{
    static void Main(string[] args)
    {
        var result = BenchmarkRunner.Run<PrimeBenchmark>();
    }
}

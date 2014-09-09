using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public class BenchmarkResult
    {

        public BenchmarkResult(IBenchmark benchmark, ICache cache)
        {
            Benchmark = benchmark;
            Cache = cache;
        }

        public IBenchmark Benchmark { get; private set; }

        public ICache Cache { get; private set; }

        public Measurement Result { get; set; }

    }
}
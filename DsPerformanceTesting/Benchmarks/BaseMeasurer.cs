using System;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public abstract class BaseMeasurer : IBenchmarkMeasurer
    {
        
        protected const int TimeLimit = 3 * 60 * 1000;

        protected readonly ICache _cache;
        protected readonly IBenchmark _benchmark;

        protected BaseMeasurer(ICache cache, IBenchmark benchmark)
        {
            _cache = cache;
            _benchmark = benchmark;
        }

        protected ICache Cache
        {
            get { return _cache; }
        }

        protected IBenchmark Benchmark
        {
            get { return _benchmark; }
        }

        public abstract Measurement Measure();

        protected void CollectMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

    }
}
using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public class BenchmarkRunner : IBenchmarkRunner
    {

        private readonly ICache _cache;
        private readonly IBenchmark _benchmark;

        private readonly IBenchmarkMeasurer _measurer;

        public BenchmarkRunner(ICache cache, IBenchmark benchmark)
        {
            _cache = cache;
            _benchmark = benchmark;
            _measurer = new BenchmarkMeasurer(cache, benchmark);
        }


        public BenchmarkResult Run()
        {
            var result = new BenchmarkResult(_benchmark, _cache);

            result.Result = _measurer.Measure();

            return result;
        }

    }
}
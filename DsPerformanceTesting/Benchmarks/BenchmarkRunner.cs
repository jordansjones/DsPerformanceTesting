using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public class BenchmarkRunner : IBenchmarkRunner
    {

        private readonly ICache _cache;
        private readonly IBenchmark _benchmark;

        private readonly IBenchmarkMeasurer _singleMeasurer;

        private readonly IBenchmarkMeasurer _multiMeasurer;

        public BenchmarkRunner(ICache cache, IBenchmark benchmark)
        {
            _cache = cache;
            _benchmark = benchmark;
            _singleMeasurer = new SingleThreadedBenchmarkMeasurer(cache, benchmark);
            _multiMeasurer = new MultiThreadedBenchmarkMeasurer(cache, benchmark);
        }


        public BenchmarkResult Run()
        {
            var result = new BenchmarkResult(_benchmark, _cache);

            _benchmark.Warmup(_cache);

            result.SingleResult = _singleMeasurer.Measure();


            _benchmark.Warmup(_cache);

            result.MultiResult = _multiMeasurer.Measure();

            return result;
        }

    }
}
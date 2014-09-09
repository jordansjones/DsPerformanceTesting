using System;
using System.Diagnostics;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public class BenchmarkMeasurer : IBenchmarkMeasurer
    {

        public const int TimeLimit = 3 * 60 * 1000;

        private readonly ICache _cache;
        private readonly IBenchmark _benchmark;

        public BenchmarkMeasurer(ICache cache, IBenchmark benchmark)
        {
            _cache = cache;
            _benchmark = benchmark;
        }

        public ICache Cache
        {
            get { return _cache; }
        }

        public IBenchmark Benchmark
        {
            get { return _benchmark; }
        }


        public Measurement Measure()
        {
            CollectMemory();

            var watch = new Stopwatch();
            var result = new Measurement();

            watch.Start();
            try
            {
                var i = 0;
                foreach (var dto in Benchmark.GetTestData())
                {
                    Benchmark.DoAction(Cache, dto);
                    // If measurement takes more than 3 minutes, stop and iterpolate result
                    if (i % 500 == 0 && watch.ElapsedMilliseconds > TimeLimit)
                    {
                        watch.Stop();

                        result.Time = watch.ElapsedMilliseconds * Benchmarks.Benchmark.LoopCount / i;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(
                            " Benchmark '{0}' was stopped after {1:f1} minutes. {2} of {3} operations completed. Estimated execution time would have taken {4:f1} minutes.",
                            Benchmark.Name,
                            (double) watch.ElapsedMilliseconds / (1000 * 60),
                            i,
                            Benchmarks.Benchmark.LoopCount,
                            (double) result.Time / (1000 * 60)
                            );
                        Console.ResetColor();

                        result.ExtraPolated = true;
                        return result;
                    }
                    i++;
                }
            }
            catch(Exception e)
            {
                CollectMemory();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    " Benchmark '{0}' failed: {1}",
                    Benchmark.Name,
                    e.Message);
                Console.ResetColor();

                result.Error = e is OutOfMemoryException ? "OoM" : "Error";
            }

            watch.Stop();

            if (result.Error == null)
            {
                result.Time = watch.ElapsedMilliseconds;
            }

            return result;
        }

        public void CollectMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }


    }
}
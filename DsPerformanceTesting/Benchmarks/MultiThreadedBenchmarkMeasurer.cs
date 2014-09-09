using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public class MultiThreadedBenchmarkMeasurer : BaseMeasurer
    {

        private const int NumberOfThreads = 5;

        private readonly ConcurrentBag<long> _results = new ConcurrentBag<long>();

        public MultiThreadedBenchmarkMeasurer(ICache cache, IBenchmark benchmark) : base(cache, benchmark) {}

        public override Measurement Measure()
        {
            CollectMemory();

            var result = new Measurement();
            Exception ex = null;

            var testData = Benchmark.GetTestData();
            var parallelQuery = (Benchmark is IOrdered) ? testData.AsParallel().AsOrdered() : testData.AsParallel()
                     .WithDegreeOfParallelism(NumberOfThreads)
                     .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                     .WithMergeOptions(ParallelMergeOptions.FullyBuffered);
            
            var cts = new CancellationTokenSource(TimeLimit + 10);
            try
            {
                parallelQuery.WithCancellation(cts.Token)
                             .ForAll(MeasureInternal);
            }
            catch (TimeoutException te)
            {
                CollectMemory();
                result.ExtraPolated = true;
                ex = te;
            }
            catch (Exception e)
            {
                CollectMemory();
                result.ExtraPolated = true;
                ex = e;
            }

            var completed = _results.Count;
            result.Time = _results.Sum();

            if (ex != null)
            {
                result.Error = ex is OutOfMemoryException ? "OoM" : ex.Message;
                var estimatedTime = completed > 0 ? _results.Average() * Benchmarks.Benchmark.LoopCount / completed : 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    " Benchmark '{0}' (multi) was stopped after {1:f1} minutes. About {2} of {3} operations completed. Estimated execution time would have taken {4:f1} minutes.",
                    Benchmark.Name,
                    (double) result.Time / (1000 * 60),
                    completed,
                    Benchmarks.Benchmark.LoopCount,
                    estimatedTime
                    );
                Console.ResetColor();
            }

            return result;
        }

        private void MeasureInternal(IServiceDto dto)
        {
            var sw = Stopwatch.StartNew();
            Benchmark.DoAction(Cache, dto);
            sw.Stop();
            _results.Add(sw.ElapsedMilliseconds);
        }

    }
}
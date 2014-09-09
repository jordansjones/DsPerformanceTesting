using System;
using System.Diagnostics;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public class SingleThreadedBenchmarkMeasurer : BaseMeasurer
    {


        public SingleThreadedBenchmarkMeasurer(ICache cache, IBenchmark benchmark)
            :base(cache, benchmark)
        {}


        public override Measurement Measure()
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
                            " Benchmark '{0}' (single) was stopped after {1:f1} minutes. {2} of {3} operations completed. Estimated execution time would have taken {4:f1} minutes.",
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


    }
}
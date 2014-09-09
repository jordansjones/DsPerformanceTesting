using System;
using System.Collections.Generic;
using System.Linq;

using DsPerformanceTesting.Benchmarks;
using DsPerformanceTesting.Output;

namespace DsPerformanceTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var caches = CacheFactory.CreateCaches().ToArray();
            var benchmarks = BenchmarkFactory.CreateBenchmarks().ToArray();

            DataFactory.InitializeData();

            var results = new List<BenchmarkResult>();

            foreach (var cache in caches)
            {
                var cacheResults = new List<BenchmarkResult>();

                Console.WriteLine(
                    "{0}",
                    cache.Name);

                foreach (var benchmark in benchmarks)
                {
                    var result = new BenchmarkRunner(cache, benchmark).Run();

                    cacheResults.Add(result);

                    Console.WriteLine(
                        " {0} {1,10} / {2}",
                        result.Benchmark.Name,
                        result.SingleResult,
                        result.MultiResult);
                }

                cache.Dispose();

                results.AddRange(cacheResults);

                Console.WriteLine();
            }

            var output = new MultiOutput(
                new HtmlOutput()
                );

            output.Create(benchmarks, results);

            Console.WriteLine("Done");
#if DEBUG
            Console.ReadLine();

#endif

        }
    }
}

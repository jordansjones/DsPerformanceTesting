using System;
using System.Collections.Generic;
using System.Linq;

using DsPerformanceTesting.Benchmarks;

namespace DsPerformanceTesting
{
    internal static class BenchmarkFactory
    {

        public static IEnumerable<IBenchmark> CreateBenchmarks()
        {
            return typeof (BenchmarkFactory).Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && typeof (IBenchmark).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<IBenchmark>()
                .OrderBy(x => x.Order);
        }

    }
}

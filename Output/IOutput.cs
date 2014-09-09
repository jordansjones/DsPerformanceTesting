using System;
using System.Collections.Generic;
using System.Linq;

using DsPerformanceTesting.Benchmarks;

namespace DsPerformanceTesting.Output
{
    public interface IOutput
    {
        
        void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults);

    }
}

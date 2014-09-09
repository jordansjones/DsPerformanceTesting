using System;
using System.Linq;

namespace DsPerformanceTesting.Benchmarks
{
    public interface IBenchmarkRunner
    {

        BenchmarkResult Run();

    }
}

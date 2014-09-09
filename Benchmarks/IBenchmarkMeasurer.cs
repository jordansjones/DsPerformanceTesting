using System;
using System.Linq;

namespace DsPerformanceTesting.Benchmarks
{
    public interface IBenchmarkMeasurer
    {

        Measurement Measure();

    }
}

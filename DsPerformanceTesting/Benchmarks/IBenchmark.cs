using System.Collections.Generic;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public interface IBenchmark
    {

        string Name { get; }

        int Order { get; }

        void DoAction(ICache cache, IServiceDto serviceDto);

        IEnumerable<IServiceDto> GetTestData();

    }
}
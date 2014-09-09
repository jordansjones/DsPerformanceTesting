using System.Collections.Generic;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public interface IBenchmark
    {

        string Name { get; }

        int Order { get; }

        void Warmup(ICache cache);

        void DoAction(ICache cache, IServiceDto serviceDto);

        IReadOnlyList<IServiceDto> GetTestData();

    }

    public interface IOrdered
    {

    }
}
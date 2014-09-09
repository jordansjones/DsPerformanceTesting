using System.Collections.Generic;
using System.Linq;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks.Basic
{
    public class Insertion_01_Benchmark : Benchmark, IOrdered
    {

        public override IReadOnlyList<IServiceDto> GetTestData()
        {
            return DataFactory.ServiceDtos;
        }

        public override void Warmup(ICache cache)
        {
            cache.Reset(Enumerable.Empty<IServiceDto>());
        }

        public override void DoAction(ICache cache, IServiceDto serviceDto)
        {
            cache.Add(serviceDto);
        }

    }
}
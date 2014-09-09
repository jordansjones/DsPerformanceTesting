using System.Collections.Generic;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks.Basic
{
    public class Insertion_01_Benchmark : Benchmark
    {

        public override IEnumerable<IServiceDto> GetTestData()
        {
            return DataFactory.ServiceDtos;
        }

        public override void DoAction(ICache cache, IServiceDto serviceDto)
        {
            cache.Add(serviceDto);
        }

    }
}
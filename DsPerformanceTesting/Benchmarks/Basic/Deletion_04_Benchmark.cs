using System.Linq;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks.Basic
{
    public class Deletion_04_Benchmark : Benchmark
    {

        public override void Warmup(ICache cache)
        {
            cache.Reset(GetTestData());
        }

        public override void DoAction(ICache cache, IServiceDto dto)
        {
            cache.Remove(dto);
        }

    }
}
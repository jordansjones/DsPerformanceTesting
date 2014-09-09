using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks.Basic
{
    public class Fetch_03_Benchmark : Benchmark
    {


        public override void DoAction(ICache cache, IServiceDto dto)
        {
            cache.Fetch(dto);
        }

    }
}
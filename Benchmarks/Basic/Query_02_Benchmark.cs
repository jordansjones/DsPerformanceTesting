using System.Collections.Generic;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks.Basic
{
    public class Query_02_Benchmark : Benchmark
    {


        public override void DoAction(ICache cache, IServiceDto dto)
        {
            cache.Contains(dto);
        }

    }
}
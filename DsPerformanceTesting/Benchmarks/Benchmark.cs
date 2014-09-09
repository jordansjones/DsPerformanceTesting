using System.Collections.Generic;
using System.Text.RegularExpressions;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Benchmarks
{
    public abstract class Benchmark : IBenchmark
    {

#if DEBUG
        public const int LoopCount = 80;
#else
        public const int LoopCount = 800 * 1000;
#endif


        public string Name
        {
            get
            {
                var name = GetType().Name.Split('_')[0];
                return Regex.Replace(name, "[A-Z]+", m => " " + m.Value).TrimStart();
            }
        }

        public int Order
        {
            get { return int.Parse(GetType().Name.Split('_')[1]); }
        }

        public virtual void Warmup(ICache cache)
        { }

        public virtual IReadOnlyList<IServiceDto> GetTestData()
        {
            return DataFactory.ServiceDtos;
        }


        public abstract void DoAction(ICache cache, IServiceDto serviceDto);

    }
}
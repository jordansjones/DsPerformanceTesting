using System;
using System.Collections.Generic;
using System.Linq;

using DsPerformanceTesting.Benchmarks;

namespace DsPerformanceTesting.Output
{
    public class MultiOutput : IOutput
    {

        private readonly IEnumerable<IOutput> outputs;

        public MultiOutput(params IOutput[] outputs)
        {
            this.outputs = outputs;
        }

        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            foreach (var output in outputs)
            {
                output.Create(benchmarks, benchmarkResults);
            }
        }

    }

}
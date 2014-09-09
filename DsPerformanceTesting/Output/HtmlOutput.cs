using System.Collections.Generic;
using System.IO;
using System.Linq;

using DsPerformanceTesting.Benchmarks;
using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting.Output
{
    public class HtmlOutput : IOutput
    {
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            using (var fileStream = new FileStream("output\\result.html", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write("<html><body><table>");
                    writer.Write("<thead><tr><th>Container</th>");

                    foreach (var benchmark in benchmarks)
                    {
                        writer.Write("<th>{0}</th>", benchmark.Name);
                    }

                    writer.WriteLine("</tr></thead><tbody>");

                    foreach (var container in benchmarkResults.Select(r => r.Cache).Distinct())
                    {
                        writer.Write("<tr>");
                        writer.Write("<th>{0}</th>", GetName(container));

                        foreach (var benchmark in benchmarks)
                        {
                            var resultsOfBenchmark = benchmarkResults.Where(r => r.Benchmark == benchmark);
                            var containerResult = resultsOfBenchmark.First(r => r.Cache == container);

                            writer.Write(
                                "<td style=\"text-align:right;\"><span title=\"Single thread\">{0}</span> / <span title=\"Multi thread\">{1}</span></td>",
                                containerResult.SingleResult,
                                containerResult.MultiResult);
                        }

                        writer.WriteLine("</tr></tbody>");
                    }
                    writer.Write("</table></body></html>");
                }
            }
        }

        private static string GetName(ICache cache)
        {
            return cache.Name;
        }

    }
}
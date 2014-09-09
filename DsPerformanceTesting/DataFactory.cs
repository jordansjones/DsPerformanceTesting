using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using CsvHelper;

using DsPerformanceTesting.Benchmarks;
using DsPerformanceTesting.Classes;

using Ploeh.AutoFixture;

namespace DsPerformanceTesting
{
    internal static class DataFactory
    {

        private static int _groupId;

        private static int _accountId;

        private static int _systemId;

        private static int _userId;

        private static IServiceDto[] _serviceDtos;

        private static IServiceDto[] _randomizedServiceDtos;

        public static IReadOnlyList<IServiceDto> ServiceDtos { get { return _serviceDtos; } }

        public static IReadOnlyList<IServiceDto> RandomizedServiceDtos { get { return _randomizedServiceDtos; } }

        public static void InitializeData()
        {

            const int totalLoops = Benchmark.LoopCount / 4;
            var serviceData = new List<IServiceDto>(Benchmark.LoopCount);

            Console.WriteLine("Generating {0} Service Dtos", Benchmark.LoopCount);

            serviceData.AddRange(GenerateData<GroupDto>(totalLoops, x => x.Id = Interlocked.Increment(ref _groupId)));
            serviceData.AddRange(GenerateData<ManagedAccountDto>(totalLoops, x => x.Id = Interlocked.Increment(ref _accountId)));
            serviceData.AddRange(GenerateData<ManagedSystemDto>(totalLoops, x => x.Id = Interlocked.Increment(ref _systemId)));
            serviceData.AddRange(GenerateData<UserDto>(totalLoops, x => x.Id = Interlocked.Increment(ref _userId)));

            _serviceDtos = serviceData.ToArray();
            _randomizedServiceDtos = _serviceDtos.OrderBy(_ => Guid.NewGuid()).ToArray();

            Console.WriteLine();
            Console.WriteLine("Completed Generating Service Dtos");
        }

        private static IEnumerable<T> GenerateData<T>(int total, Action<T> idSetter)
            where T : IServiceDto
        {
            var typeName = typeof (T).Name;
            var fileName = string.Concat(typeName, ".csv");
            if (File.Exists(fileName))
            {
                using (var fs = File.OpenRead(fileName))
                using (var sr = new StreamReader(fs))
                using (var csv = new CsvReader(sr))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    while (csv.Read())
                    {
                        yield return csv.GetRecord<T>();
                    }
                }
            }
            else
            { 
                var fixture = new Fixture();
                fixture.Customize(new NumericSequencePerTypeCustomization());
                fixture.Customize<T>(x => x.WithAutoProperties().With(p => p.Id).Do(idSetter));

                using (var fs = File.CreateText(fileName))
                using (var csv = new CsvWriter(fs))
                {
                    foreach (var dto in fixture.CreateMany<T>(total))
                    {
                        csv.WriteRecord(dto);
                        yield return dto;
                    }
                }
            }
        }

    }
}

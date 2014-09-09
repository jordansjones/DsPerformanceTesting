using System;
using System.Collections.Generic;

namespace DsPerformanceTesting.Classes
{
    public interface ICache : IDisposable
    {

        string Name { get; }

        bool Enabled { get; }

        void Reset(IEnumerable<IServiceDto> dtos);

        void Add(IServiceDto dto);

        bool Contains(IServiceDto dto);

        IServiceDto Fetch(IServiceDto dto);

        void Remove(IServiceDto dto);

    }
}
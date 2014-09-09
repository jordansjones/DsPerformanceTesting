using System;

namespace DsPerformanceTesting.Classes
{
    public interface ICache : IDisposable
    {

        string Name { get; }

        bool Enabled { get; }

        void Add(IServiceDto dto);

        bool Contains(IServiceDto dto);

        IServiceDto Fetch(IServiceDto dto);

        void Remove(IServiceDto dto);

    }
}
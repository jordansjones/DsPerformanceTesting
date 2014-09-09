using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class DtoKeyedCollection : ICache
    {
        
        private readonly object _locker = new object();
        private readonly MyKeyedCollection _cache = new MyKeyedCollection();

        public bool Enabled { get { return false; } }

        public string Name
        {
            get { return "KeyedCollection"; }
        }

        public void Reset(IEnumerable<IServiceDto> dtos)
        {
            _cache.Clear();
            if (dtos.Any())
            {
                foreach (var dto in dtos)
                {
                    _cache.Add(dto);
                }
            }
        }

        public void Add(IServiceDto dto)
        {
            using (TimedLock.Lock(_locker))
            {
                _cache.Add(dto);
            }
        }

        public bool Contains(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            using (TimedLock.Lock(_locker))
            {
                return _cache.Contains(key);
            }
        }

        public IServiceDto Fetch(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            using (TimedLock.Lock(_locker))
            {
                return _cache[key];
            }
        }

        public void Remove(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            using (TimedLock.Lock(_locker))
            {
                _cache.Remove(key);
            }
        }

        public void Dispose()
        {
            _cache.Clear();
        }

        private class MyKeyedCollection : KeyedCollection<CacheKey, IServiceDto>
        {

            protected override CacheKey GetKeyForItem(IServiceDto item)
            {
                return item.GetCacheKey();
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using C5;

namespace DsPerformanceTesting.Classes
{
    public class DtoTree : ICache
    {
        
        private readonly object _locker = new object();
        private readonly TreeDictionary<CacheKey, IServiceDto> _cache = new TreeDictionary<CacheKey, IServiceDto>();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "TreeDictionary"; }
        }

        public void Reset(IEnumerable<IServiceDto> dtos)
        {
            _cache.Clear();
            if (dtos.Any())
            {
                foreach (var dto in dtos)
                {
                    _cache[dto.GetCacheKey()] = dto;
                }
            }
        }

        public void Add(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            using (TimedLock.Lock(_locker))
            {
                _cache.Add(key, dto);
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

    }
}

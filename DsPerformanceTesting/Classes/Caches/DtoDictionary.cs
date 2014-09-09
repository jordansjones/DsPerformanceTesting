using System;
using System.Collections.Generic;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class DtoDictionary : ICache
    {

        private readonly object _locker = new object();
        private readonly Dictionary<CacheKey, IServiceDto> _cache = new Dictionary<CacheKey, IServiceDto>();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "Dictionary"; }
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
                return _cache.ContainsKey(key);
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

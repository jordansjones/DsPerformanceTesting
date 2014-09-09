using System;
using System.Collections.Generic;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class DtoDictionary : ICache
    {

        private readonly Dictionary<CacheKey, IServiceDto> _cache = new Dictionary<CacheKey, IServiceDto>();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "Dictionary"; }
        }

        public void Add(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            _cache.Add(key, dto);
        }

        public bool Contains(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            return _cache.ContainsKey(key);
        }

        public IServiceDto Fetch(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            return _cache[key];
        }

        public void Remove(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            _cache.Remove(key);
        }

        public void Dispose()
        {
            _cache.Clear();
        }

    }
}

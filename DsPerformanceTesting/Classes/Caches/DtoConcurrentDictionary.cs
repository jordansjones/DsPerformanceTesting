using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class DtoConcurrentDictionary : ICache
    {
        private readonly ConcurrentDictionary<CacheKey, IServiceDto> _cache = new ConcurrentDictionary<CacheKey, IServiceDto>();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "ConcurrentDictionary"; }
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
            _cache.TryAdd(key, dto);
        }

        public bool Contains(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            return _cache.ContainsKey(key);
        }

        public IServiceDto Fetch(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            _cache.TryGetValue(key, out dto);
            return dto;
        }

        public void Remove(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            _cache.TryRemove(key, out dto);
        }

        public void Dispose()
        {
            _cache.Clear();
        }
         

    }
}
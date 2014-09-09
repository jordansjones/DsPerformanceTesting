using System.Collections.Concurrent;

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
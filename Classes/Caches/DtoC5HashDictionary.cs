using C5;

namespace DsPerformanceTesting.Classes
{
    public class DtoC5HashDictionary : ICache
    {

        private readonly HashDictionary<CacheKey, IServiceDto> _cache = new HashDictionary<CacheKey, IServiceDto>();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "C5HashDictionary"; }
        }

        public void Add(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            _cache.Add(key, dto);
        }

        public bool Contains(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            return _cache.Contains(key);
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
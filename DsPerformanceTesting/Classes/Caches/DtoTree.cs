using System;
using System.Linq;

using C5;

namespace DsPerformanceTesting.Classes
{
    public class DtoTree : ICache
    {

        private readonly TreeDictionary<CacheKey, IServiceDto> _cache = new TreeDictionary<CacheKey, IServiceDto>();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "TreeDictionary"; }
        }

        public void Add(IServiceDto dto)
        {
            var key = dto.GetCacheKey();
            if (_cache.Contains(key))
            {
                Console.Error.WriteLine("Duplicate Key: {0}", key);
            }
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

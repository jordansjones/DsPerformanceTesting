using System.Collections;

namespace DsPerformanceTesting.Classes
{
    public class DtoHashTable : ICache
    {

        private readonly Hashtable _cache = new Hashtable();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "Hashtable"; }
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
            return (IServiceDto) _cache[key];
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
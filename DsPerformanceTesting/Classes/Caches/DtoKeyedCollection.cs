using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class DtoKeyedCollection : ICache
    {

        private readonly MyKeyedCollection _cache = new MyKeyedCollection();

        public bool Enabled { get { return false; } }

        public string Name
        {
            get { return "KeyedCollection"; }
        }

        public void Add(IServiceDto dto)
        {
            _cache.Add(dto);
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

        private class MyKeyedCollection : KeyedCollection<CacheKey, IServiceDto>
        {

            protected override CacheKey GetKeyForItem(IServiceDto item)
            {
                return item.GetCacheKey();
            }

        }

    }
}

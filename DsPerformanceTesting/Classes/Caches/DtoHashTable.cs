using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public class DtoHashTable : ICache
    {
        
        private readonly object _locker = new object();
        private readonly Hashtable _cache = new Hashtable();

        public bool Enabled { get { return true; } }

        public string Name
        {
            get { return "Hashtable"; }
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
                return (IServiceDto) _cache[key];
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
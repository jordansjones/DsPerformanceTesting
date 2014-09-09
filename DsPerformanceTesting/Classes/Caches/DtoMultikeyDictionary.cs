using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    // This is junk. I'm not even sure it works correctly.
    public class DtoMultikeyDictionary : ICache
    {

        private readonly ConcurrentDictionary<Type, Dictionary<IDtoKey, IServiceDto>> _cache = new ConcurrentDictionary<Type, Dictionary<IDtoKey, IServiceDto>>();

        public string Name
        {
            get { return "MultikeyDictionary"; }
        }

        public bool Enabled
        {
            get { return true; }
        }

        public void Reset(IEnumerable<IServiceDto> dtos)
        {
            _cache.Clear();
            foreach (var dto in dtos)
            {
                var dtoType = dto.GetType();
                var dict = _cache.GetOrAdd(dtoType, _ => new Dictionary<IDtoKey, IServiceDto>());

                dict.Add(dto.GetKey(), dto);
            }
        }

        public void Add(IServiceDto dto)
        {
            var dtoType = dto.GetType();
            var dtoKey = dto.GetKey();
            Dictionary<IDtoKey, IServiceDto> cache;
            using (LockType(dtoType, out cache))
            {
                cache.Add(dtoKey, dto);
            }
        }

        public bool Contains(IServiceDto dto)
        {
            var dtoType = dto.GetType();
            var dtoKey = dto.GetKey();
            Dictionary<IDtoKey, IServiceDto> cache;
            using (LockType(dtoType, out cache))
            {
                return cache.ContainsKey(dtoKey);
            }
        }

        public IServiceDto Fetch(IServiceDto dto)
        {
            var dtoType = dto.GetType();
            var dtoKey = dto.GetKey();
            Dictionary<IDtoKey, IServiceDto> cache;
            using (LockType(dtoType, out cache))
            {
                return cache[dtoKey];
            }
        }

        public void Remove(IServiceDto dto)
        {
            var dtoType = dto.GetType();
            var dtoKey = dto.GetKey();
            Dictionary<IDtoKey, IServiceDto> cache;
            using (LockType(dtoType, out cache))
            {
                cache.Remove(dtoKey);
            }
        }


        public void Dispose()
        {
            _cache.Clear();
        }

        private TimedLock LockType(Type dtoType, out Dictionary<IDtoKey, IServiceDto> cache)
        {
            cache = _cache.GetOrAdd(dtoType, CreateLock);
            return TimedLock.Lock(cache);
        }

        private Dictionary<IDtoKey, IServiceDto> CreateLock(Type dtoType)
        {
            Debug.WriteLine("This should happen 4 times");
            return new Dictionary<IDtoKey, IServiceDto>();
        }

    }
}

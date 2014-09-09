using System;
using System.Collections.Generic;
using System.Linq;

using DsPerformanceTesting.Classes;

namespace DsPerformanceTesting
{
    internal static class CacheFactory
    {

        public static IEnumerable<ICache> CreateCaches()
        {
            return typeof (CacheFactory).Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && typeof (ICache).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<ICache>()
                .Where(x => x.Enabled)
                .OrderBy(x => x.Name);
        }

    }
}

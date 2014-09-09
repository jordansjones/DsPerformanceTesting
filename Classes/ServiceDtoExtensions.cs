namespace DsPerformanceTesting.Classes
{
    public static class ServiceDtoExtensions
    {

        public static CacheKey GetCacheKey(this IServiceDto This)
        {
            return new CacheKey(This.GetKey(), This.GetType());
        }

    }
}
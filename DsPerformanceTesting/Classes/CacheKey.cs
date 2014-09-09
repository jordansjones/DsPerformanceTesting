using System;

namespace DsPerformanceTesting.Classes
{
    public struct CacheKey : IEquatable<CacheKey>, IComparable<CacheKey>
    {

        private readonly string _comparitor;

        public IDtoKey DtoKey { get; private set; }

        public string DtoType { get; private set; }

        public CacheKey(IDtoKey dtoKey, Type dtoType)
            :this()
        {
            DtoKey = dtoKey;
            DtoType = dtoType.Name;
            _comparitor = string.Concat(DtoKey.Value, "_", DtoType);
        }

        public override string ToString()
        {
            return string.Format("DtoKey: {0}, DtoType: {1}", DtoKey, DtoType);
        }

        public bool Equals(CacheKey other)
        {
            return DtoKey.Equals(other.DtoKey) && DtoType.Equals(other.DtoType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            return obj is CacheKey && Equals((CacheKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked { return (DtoKey.GetHashCode() * 397) ^ DtoType.GetHashCode(); }
        }

        public int CompareTo(CacheKey other)
        {
            return String.CompareOrdinal(_comparitor, other._comparitor);
        }

    }
}
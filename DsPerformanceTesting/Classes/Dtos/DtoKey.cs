using System;
using System.Collections.Generic;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public interface IDtoKey : IEquatable<IDtoKey>, IComparable<IDtoKey>
    {

        string Value { get; }
        string AsUrlKey();

    }

    #region Base Dto Key

    internal abstract class BaseDtoKey : IDtoKey
    {

        protected BaseDtoKey(string value)
        {
            Value = value;
        }

        protected BaseDtoKey() : this(string.Empty) {}

        protected BaseDtoKey(IEnumerable<string> values) : this(string.Join(",", values)) {}

        public string Value { get; private set; }

        public string AsUrlKey()
        {
            return Value;
        }

        protected void SetValue(string value)
        {
            Value = value;
        }

        public int CompareTo(IDtoKey other)
        {
            return String.Compare(Value, other.Value, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return AsUrlKey();
        }

        internal static string FormatStringValue(string value)
        {
            return string.Format("'{0}'", value);
        }

        #region Equality

        public bool Equals(IDtoKey other)
        {
            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return string.Equals(AsUrlKey(), other.AsUrlKey());
        }

        public bool Equals(BaseDtoKey other)
        {
            if (ReferenceEquals(null, other)) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            if (obj.GetType() != GetType()) { return false; }
            return Equals((BaseDtoKey) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(BaseDtoKey left, IDtoKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseDtoKey left, IDtoKey right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(IDtoKey left, BaseDtoKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IDtoKey left, BaseDtoKey right)
        {
            return !Equals(left, right);
        }

        #endregion

    }

    #endregion


    #region DtoKey

    internal sealed class DtoKey : BaseDtoKey
    {

        public DtoKey(IEnumerable<string> values) : base(values) {}

        public DtoKey(string value) : base(FormatStringValue(value)) {}

        public DtoKey(char value) : base(Convert.ToString(value)) {}

        public DtoKey(byte value) : base(Convert.ToString(value)) {}

        public DtoKey(short value) : base(Convert.ToString(value)) {}

        public DtoKey(int value) : base(Convert.ToString(value)) {}

        public DtoKey(long value) : base(Convert.ToString(value)) {}

        public DtoKey(float value) : base(Convert.ToString(value)) {}

        public DtoKey(double value) : base(Convert.ToString(value)) {}

        public DtoKey(decimal value) : base(Convert.ToString(value)) {}

        public DtoKey(Enum value) : this(Enum.GetName(value.GetType(), value)) {}

    }

    #endregion

}

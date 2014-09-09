using System;
using System.Linq;

namespace DsPerformanceTesting.Benchmarks
{
    public struct Measurement
    {

        public long? Time { get; set; }

        public bool ExtraPolated { get; set; }

        public string Error { get; set; }

        public bool Successful { get { return string.IsNullOrEmpty(Error) && !ExtraPolated && Time.HasValue; } }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Error))
            {
                return Error;
            }
            else
            {
                return string.Format(
                    "{0}{1}",
                    Time,
                    ExtraPolated ? "*" : null);
            }
        }

    }
}

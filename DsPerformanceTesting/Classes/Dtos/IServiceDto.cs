using System;
using System.Linq;

namespace DsPerformanceTesting.Classes
{
    public interface IServiceDto
    {

        int Id { get; set; }

        IDtoKey GetKey();

    }

    public interface IServiceDto<T> : IServiceDto
        where T : class, IServiceDto<T>
    {

    }
}

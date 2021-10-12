using System;
using System.Collections.Generic;
using System.Text;

namespace FakerInterfaces
{
    public interface IGeneratorContext
    {
        Random Random { get; }
        Type TargetType { get; }
        IFaker Faker { get; }
    }
}

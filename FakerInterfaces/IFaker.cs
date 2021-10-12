using System;

namespace FakerInterfaces
{
    public interface IFaker
    {
        T Create<T>();
        object Create(Type type);
    }
}

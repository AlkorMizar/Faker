using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerInterfaces
{
    public interface IValueGenerator
    {
        object Generate(IGeneratorContext context);
        bool CanGenerate(Type type);
    }

}

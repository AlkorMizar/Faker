using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerAPI.API
{
    public interface IValueGenerator
    {
        object Generate(GeneratorContext context);
        bool CanGenerate(Type type);
    }

}

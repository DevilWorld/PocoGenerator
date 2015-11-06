using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;

namespace PocoGenerator.Domain.Interfaces.Templates
{
    public interface ITemplate<T> where T : class
    {
        Template GetTemplate();
    }
}

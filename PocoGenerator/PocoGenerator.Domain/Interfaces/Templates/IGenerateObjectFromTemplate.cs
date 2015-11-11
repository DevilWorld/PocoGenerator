using System;
using System.Collections.Generic;
using System.Linq;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Interfaces.Templates
{
    public interface IGenerateObjectFromTemplate<T> 
                where T : class
    {
        string Generate(ITemplate<T> template, SysObjects sysobject);

        void GetTemplateObject(ObjectTemplate templateType);//remove this
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Interfaces.Templates
{
    public interface IGenerateTemplate
    {
        //Generate templates at the higher level
        string Generate(TemplateType templateType, SysObjects sysObjects = null, SysColumns sysColumns = null, KeyColumnNames keyColumnsNames = null);
    }
}

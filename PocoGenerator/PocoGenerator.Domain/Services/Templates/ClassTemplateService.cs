using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces.Templates;
using DotLiquid;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Domain.Services.Templates
{
    public class ClassTemplateService : ITemplate<SysObjects, ClassTemplateService>
    {
        //private readonly ITemplate<SysColumns, PropertiesTemplateSevice> _propertiesTemplateService;

        //public ClassTemplateService(ITemplate<SysColumns, PropertiesTemplateSevice> propertiesTemplateService)
        //{
        //    _propertiesTemplateService = propertiesTemplateService;
        //}

        public Template GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();            
            sbTemplate.Append("public class {{table.name}}");
            sbTemplate.AppendLine();
            sbTemplate.Append("{");
            sbTemplate.AppendLine();
            sbTemplate.Append("{{columns}}");
            sbTemplate.Append("}");

            return Template.Parse(sbTemplate.ToString());
        }
    }
}

using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;

namespace PocoGenerator.Domain.Services.Templates
{
    public class NamespaceTemplateService : ITemplate<SysObjects, NamespaceTemplateService>
    {
        //private readonly ITemplate<SysObjects, ClassTemplateService> _classTemplateService;

        //public NamespaceTemplateService(ITemplate<SysObjects, ClassTemplateService> classTemplateService)
        //{
        //    _classTemplateService = classTemplateService;
        //}

        public Template GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();

            sbTemplate.Append("namespace ");
            sbTemplate.AppendLine();
            sbTemplate.Append("{");
            sbTemplate.AppendLine();
            //sbTemplate.Append("\t");
            sbTemplate.Append("{{class}}");
            sbTemplate.AppendLine();
            sbTemplate.Append("}");

            return Template.Parse(sbTemplate.ToString());
        }
    }
}

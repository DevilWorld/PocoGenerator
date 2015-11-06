using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces.Templates;

namespace PocoGenerator.Domain.Services.Templates
{
    public class ClassTemplateService : ITemplate<ClassTemplateService>
    {
        private readonly ITemplate<PropertiesTemplateSevice> _propertiesTemplateService;

        public ClassTemplateService(ITemplate<PropertiesTemplateSevice> propertiesTemplateService)
        {
            _propertiesTemplateService = propertiesTemplateService;
        }

        public string GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append("public class {{className}}");
            sbTemplate.AppendLine();
            sbTemplate.Append("{");
            sbTemplate.AppendLine();
            sbTemplate.Append("\t");
            sbTemplate.Append(_propertiesTemplateService.GetTemplate());
            sbTemplate.AppendLine();
            sbTemplate.Append("}");

            return sbTemplate.ToString();

        }
    }
}

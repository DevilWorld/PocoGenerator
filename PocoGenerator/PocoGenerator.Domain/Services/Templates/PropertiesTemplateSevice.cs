using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces.Templates;

namespace PocoGenerator.Domain.Services.Templates
{
    public class PropertiesTemplateSevice : ITemplate<PropertiesTemplateSevice>
    {
        public string GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append("\t");
            sbTemplate.AppendLine();

            return sbTemplate.ToString();
        }
    }
}

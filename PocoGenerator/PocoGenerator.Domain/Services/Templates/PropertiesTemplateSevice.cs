using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Services.Templates
{
    public class PropertiesTemplateSevice : ITemplate<SysColumns>
    {
        public PropertiesTemplateSevice()
        { }

        public Template GetTemplate()
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append("\t");
            sbTemplate.AppendLine();

            return Template.Parse(sbTemplate.ToString());
        }
    }
}

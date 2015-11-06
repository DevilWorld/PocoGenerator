using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Services.Templates
{
    public class GenerateTemplateService : IGenerateTemplate
    {
        private readonly ITemplate<ClassTemplateService> _template;

        public GenerateTemplateService(ITemplate<ClassTemplateService> template)
        {
            _template = template;
        }

        public string Generate(ObjectTemplate objectType, SysObjects sysobjects)
        {
            if (objectType == ObjectTemplate.Class)
            {
                Template templateClass = Template.Parse(_template.GetTemplate());
                
                templateClass.Render();
            }

            return string.Empty;
        }        
    }
}

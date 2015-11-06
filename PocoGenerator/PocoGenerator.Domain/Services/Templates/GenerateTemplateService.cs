using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.DotLiquidDrops;

namespace PocoGenerator.Domain.Services.Templates
{
    public class GenerateTemplateService : IGenerateObjectFromTemplate<>
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
                Template templateClass = _template.GetTemplate();

                var result = templateClass.Render(
                    Hash.FromAnonymousObject(
                        new {sysobjects = new SysObjectsDrop(sysobjects)}));
            }

            return string.Empty;
        }
    }
}

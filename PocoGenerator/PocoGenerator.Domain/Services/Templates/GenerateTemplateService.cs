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
using PocoGenerator.Common;

namespace PocoGenerator.Domain.Services.Templates
{
    public class GenerateTemplateService : IGenerateObjectFromTemplate<GenerateTemplateService>
    {
        private readonly ITemplate<ClassTemplateService> _template;

        public GenerateTemplateService(ITemplate<ClassTemplateService> template)
        {
            _template = template;
        }

        public void GetTemplateObject(ObjectTemplate templateType)
        {
            switch (templateType)
            {
                case ObjectTemplate.Class:
                    {
                        var template = Global.ParsedTemplates[ObjectTemplate.Class];
                        var result = template.Render(Hash.FromAnonymousObject(new { sysobjects = new SysObjectsDrop(new SysObjects() { name = "tblAddress" }) }));
                        break;
                    }
                default:
                    {
                        var template = Global.ParsedTemplates[ObjectTemplate.Class];
                        break;                        
                    }
            }            
        }

        public string Generate(ITemplate<GenerateTemplateService> template, SysObjects sysobject)
        {
            //if (objectType == ObjectTemplate.Class)
            //{
            //    Template templateClass = _template.GetTemplate();

            //    var result = templateClass.Render(
            //        Hash.FromAnonymousObject(
            //            new { sysobjects = new SysObjectsDrop(sysobjects) }));
            //}

            return string.Empty;
        }
    }
}

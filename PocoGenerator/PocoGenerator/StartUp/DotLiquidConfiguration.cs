using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DotLiquid;
using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Services.Templates;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.StartUp
{
    internal class DotLiquidConfiguration
    {
        public static void Configue()
        {
            using (var scope = Global.Container.BeginLifetimeScope())
            {
                

                Dictionary<ObjectTemplate, Template> parsedTemplates = new Dictionary<ObjectTemplate, Template>
                {
                    //{ ObjectTemplate.Class, scope.Resolve<ITemplate<ClassTemplateService>>().GetTemplate() },
                    { ObjectTemplate.Properties, scope.Resolve<PropertiesTemplateSevice>().GetTemplate() }
                };

                Global.ParsedTemplates = parsedTemplates;
            }
        }
    }
}

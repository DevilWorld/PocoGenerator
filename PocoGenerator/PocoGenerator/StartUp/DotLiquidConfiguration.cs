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
                Global.ParsedTemplates.Add(ObjectTemplate.Class,
                    scope.Resolve<ITemplate<ClassTemplateService>>().GetTemplate());

                Global.ParsedTemplates.Add(ObjectTemplate.Properties,
                    scope.Resolve<ITemplate<PropertiesTemplateSevice>>().GetTemplate());
            }
        }
    }
}

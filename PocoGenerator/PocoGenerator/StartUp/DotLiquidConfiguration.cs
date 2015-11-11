using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DotLiquid;
using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models;
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
                Dictionary<TemplateType, Template> parsedTemplates = new Dictionary<TemplateType, Template>
                {
                    { TemplateType.Class, scope.Resolve<ITemplate<SysObjects>>().GetTemplate() },
                    { TemplateType.Properties, scope.Resolve<ITemplate<SysColumns>>().GetTemplate() }
                };

                Global.TemplateManager = parsedTemplates;
            }
        }
    }
}

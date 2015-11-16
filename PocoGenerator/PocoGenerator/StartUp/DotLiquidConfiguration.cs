using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DotLiquid;
using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.BaseObjects;
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
                    { TemplateType.Class, scope.Resolve<ITemplate<SysObjects, ClassTemplateService>>().GetTemplate() },
                    { TemplateType.Properties, scope.Resolve<ITemplate<SysColumns, PropertiesTemplateSevice>>().GetTemplate() },
                    { TemplateType.Namespace, scope.Resolve<ITemplate<SysObjects, NamespaceTemplateService>>().GetTemplate() }
                };

                Global.TemplateManager = parsedTemplates;
            }
        }
    }
}

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
    public class GenerateTemplateService : IGenerateTemplate
    {
        //private readonly ITemplate<SysObjects> _template;

        public GenerateTemplateService(/*ITemplate<SysObjects> template*/)
        {
            //_template = template;
        }

        //public void GetTemplateObject(TemplateType templateType)
        //{
        //    switch (templateType)
        //    {
        //        case TemplateType.Class:
        //            {
        //                var template = Global.ParsedTemplates[TemplateType.Class];
        //                var result = template.Render(Hash.FromAnonymousObject(new { sysobjects = new SysObjectsDrop(new SysObjects() { name = "tblAddress" }) }));
        //                break;
        //            }
        //        default:
        //            {
        //                var template = Global.ParsedTemplates[TemplateType.Class];
        //                break;
        //            }
        //    }
        //}

        public string Generate(TemplateType templateType, SysObjects sysObjects = null, SysColumns sysColumns = null, KeyColumnNames keyColumnsNames = null)
        {
            switch (templateType)
            {
                case TemplateType.Class:
                    {
                        if (sysObjects != null)
                        {
                            var template = Global.TemplateManager[TemplateType.Class];
                            var result =
                                template.Render(
                                    Hash.FromAnonymousObject(new {@class = new SysObjectsDrop(sysObjects)}));

                            return result;
                        }
                        break;
                    }
                default:
                    {
                        var template = Global.TemplateManager[TemplateType.Class];
                        break;
                    }
            }

            return string.Empty;
        }
    }
}

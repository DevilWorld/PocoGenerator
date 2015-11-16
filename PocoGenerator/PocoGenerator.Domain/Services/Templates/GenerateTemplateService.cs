using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.DotLiquidDrops;
using PocoGenerator.Common;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Interfaces;

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
                case TemplateType.Namespace:
                    {
                        if (sysObjects != null)
                        {
                            var template = Global.TemplateManager[TemplateType.Namespace];
                            var result =
                                    template.Render(
                                    Hash.FromAnonymousObject(new
                                    {
                                        @class = GetClass(sysObjects)
                                    }));

                            return result;
                        }

                        break;
                    }

                case TemplateType.Class:
                    {
                        if (sysObjects != null)
                        {
                            return GetClass(sysObjects);
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

        private string GetClass(SysObjects sysObjects)
        {
            var template = Global.TemplateManager[TemplateType.Class];
            var result =
                template.Render(
                    Hash.FromAnonymousObject(new
                    {
                        table = new SysObjectsDrop(sysObjects),
                        columns = GetProperties(sysObjects) // get the completely generated properties
                                    }
                                            )
                                );

            return result;
        }

        /// <summary>
        /// Loop thru the columns and generatet rhe properties
        /// </summary>
        /// <param name="sysColumns"></param>
        /// <returns></returns>
        private string GetProperties(SysObjects sysObjects)
        {
            var template = Global.TemplateManager[TemplateType.Properties];

            var sbProperty = new StringBuilder();

            sysObjects.Columns.ToList().ForEach(x =>
                {
                    sbProperty.Append( template.Render(Hash.FromAnonymousObject(new
                    {
                        column = new SysColumnsDrop(x)          //template in propertiestemplateservice
                    })));
                });

            return sbProperty.ToString();
        }
    }
}

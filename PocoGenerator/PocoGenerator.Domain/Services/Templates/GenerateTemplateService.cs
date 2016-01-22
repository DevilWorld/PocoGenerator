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
using PocoGenerator.Domain.Models.Dto;

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

        public string Generate(TemplateType templateType, TablesWithColumnsDto tableWithColumns)
        {
            switch (templateType)
            {
                case TemplateType.Namespace:
                    {
                        if (tableWithColumns != null)
                        {
                            var template = Global.TemplateManager[TemplateType.Namespace];
                            var result =
                                    template.Render(
                                    Hash.FromAnonymousObject(new
                                    {
                                        @class = GetClass(tableWithColumns)
                                    }));

                            return result;
                        }

                        break;
                    }

                case TemplateType.Class:
                    {
                        if (tableWithColumns != null)
                        {
                            return GetClass(tableWithColumns);
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

        private string GetClass(TablesWithColumnsDto tableWithColumns)
        {
            var template = Global.TemplateManager[TemplateType.Class];
            //var result =
            //    template.Render(
            //        Hash.FromAnonymousObject(new
            //        {
            //            table = new TableWithColumnsDrop(sysObjects),   //use automapper to tablewithColumns to sysobjects
            //            columns = GetProperties(sysObjects) // get the completely generated properties
            //        }
            //                                )
            //                    );

            return result;

            return string.Empty;
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

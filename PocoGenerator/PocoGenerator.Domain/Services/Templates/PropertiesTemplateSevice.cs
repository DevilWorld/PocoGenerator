﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Services.BlankSpace;
using PocoGenerator.Domain.Models.Dto;
using System.Drawing;

namespace PocoGenerator.Domain.Services.Templates
{
    public class PropertiesTemplateSevice : ITemplate<SysColumns, PropertiesTemplateSevice>
    {
        IBlankSpaceService<PropertiesBlankSpaceService> _blankSpaceService;
        public PropertiesTemplateSevice(IBlankSpaceService<PropertiesBlankSpaceService> blankSpaceService)
        {
            _blankSpaceService = blankSpaceService;
        }

        public Template GetTemplate()       //Pass template type as a parameter based on the user selection.
                                            //Now it is hard-coded for development.
        {
            StringBuilder sbTemplate = new StringBuilder();
            sbTemplate.Append(_blankSpaceService.ApplyBlankSpace(Global.IsNameSpaceEnabled));    //TODO Remove template type from this ApplyBlankSpace(). We should hard-code template here bcoz this is class templates service
            sbTemplate.Append("public {{column.datatype}} {{column.name}} { get; set; }");
            sbTemplate.AppendLine();            

            return Template.Parse(sbTemplate.ToString());
        }
    }
}

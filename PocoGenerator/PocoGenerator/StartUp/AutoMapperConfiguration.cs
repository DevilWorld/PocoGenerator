using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Models.Dto;

namespace PocoGenerator.StartUp
{
    internal class AutoMapperConfiguration
    {
        internal static void Configure()
        {
            Mapper.CreateMap<TablesWithColumnsDto, SysObjects>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PocoGenerator.StartUp;
using Autofac;
using PocoGenerator.Common;
using PocoGenerator.TypeMapping;
using PocoGenerator.Domain.Interfaces;
using Autofac.Core;
using PocoGenerator.Domain.Interfaces.Templates;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Configurations
            AutofacConfiguration.Configure();
            DotLiquidConfiguration.Configue();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Test
            //using (var scope = Global.Container.BeginLifetimeScope())
            //{
            //    var templateService = scope.Resolve<IGenerateTemplate>();
            //    var result = templateService.Generate(TemplateType.Namespace, new SysObjects()
            //    {
            //        name = "tblAddress",
            //        Columns = new List<SysColumns>
            //                                {
            //                                    new SysColumns() { id=1, name="FirstName", colorder=1, DataType = new SysTypes() { name = "nvarchar"} },
            //                                    new SysColumns() { id=1, name="LastName", colorder=2, DataType = new SysTypes() { name = "nvarchar"}},
            //                                }
            //    });
            //}
            //Endof test

            using (var scope = Global.Container.BeginLifetimeScope())
            {
                Application.Run(scope.Resolve<PocoGenerator>());
                //Application.Run(scope.Resolve<TypeMapper>());
            }
        }
    }
}

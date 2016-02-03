using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PocoGenerator.StartUp;
using Autofac;
using PocoGenerator.Domain;
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
            Global.IsNameSpaceEnabled = true;
            DotLiquidConfiguration.Configure();
            AutoMapperConfiguration.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Test
            //using (var scope = Global.Container.BeginLifetimeScope())
            //{
            //    var templateService = scope.Resolve<IRetrieveDbObjectsRepository>();
            //    var result = templateService.GetColumnsWithKeys();
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

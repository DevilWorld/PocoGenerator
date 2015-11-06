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

            using (var scope = Global.Container.BeginLifetimeScope())
            {
                Application.Run(scope.Resolve<PocoGenerator>());
                //Application.Run(scope.Resolve<TypeMapper>());
            }
        }
    }
}

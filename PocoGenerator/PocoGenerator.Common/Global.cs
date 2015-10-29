using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace PocoGenerator.Common
{
    public static class Global
    {
        //Global autofac container
        public static IContainer Container { get; set; }

        public static string ConnectionString { get; set; }

        public static IDictionary<string, string> DataTypeMapper { get; set; }
    }
}

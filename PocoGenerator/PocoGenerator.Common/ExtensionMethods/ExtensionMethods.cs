using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Common.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string GetAuthenticationTypesDescription(this AuthenticationTypes e)
        {
            switch(e)
            {
                case AuthenticationTypes.WindowsAuthentication:
                    return "Windows Authentication";                    
                case AuthenticationTypes.SQLServerAuthentication:
                    return "SQL Server Authentication";
                default:
                    return string.Empty;
            }
        }
    }
}

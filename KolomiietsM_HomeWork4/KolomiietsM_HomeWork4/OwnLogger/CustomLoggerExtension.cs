using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork4.OwnLogger
{
    public static class CustomLoggerExtension //AS ALTERNATIVE #1
    {
        public static ILoggerFactory AddCustomProvider(this ILoggerFactory factory, string logsPath)
        {
            factory.AddProvider(new CustomLoggerProvider(logsPath));
            return factory;
        }
    }
}

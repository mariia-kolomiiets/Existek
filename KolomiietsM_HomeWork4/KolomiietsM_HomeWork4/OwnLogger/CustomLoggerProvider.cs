using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork4.OwnLogger
{
    [ProviderAlias("CustomLogger")]
    public class CustomLoggerProvider : ILoggerProvider
    {
        private string logsPath;
        public CustomLoggerProvider(string logsPath)
        {
            this.logsPath = logsPath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(logsPath);
        }

        public void Dispose()
        {

        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork4.OwnLogger
{
    public class CustomLogger : ILogger
    {
        private string logsPath;

        public CustomLogger(string logsPath)
        {
            this.logsPath = logsPath;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel == LogLevel.Debug) return false;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                try 
                {
                    File.AppendAllText(logsPath, formatter(state, exception) + Environment.NewLine);
                }
                catch (Exception e)
                {

                }
                    
                if (logLevel == LogLevel.Error || logLevel == LogLevel.Critical) Console.ForegroundColor = ConsoleColor.Red;
                if (logLevel == LogLevel.Warning) Console.ForegroundColor = ConsoleColor.Yellow;
                if (logLevel == LogLevel.Trace) Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (logLevel == LogLevel.Information) Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{eventId}::{logsPath}\n{ formatter(state, exception)}");
                Console.ResetColor();
            }
        }
    }
}

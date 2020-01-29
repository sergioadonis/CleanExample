using CleanExample.Common.Interfaces.Loggers;
using Newtonsoft.Json;
using System;

namespace CleanExample.ConsoleApp.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public string Trace { get; set; }
        
        public void Debug(string message, object data = null)
        {
            WriteText(message, data, LogType.DEBUG);
        }

        public void Info(string message, object data = null)
        {
            WriteText(message, data, LogType.INFO);
        }

        public void Warn(string message, object data = null)
        {
            WriteText(message, data, LogType.WARN);
        }

        public void Error(string message, object data = null)
        {
            WriteText(message, data, LogType.ERROR);
        }

        public void Fatal(string message, object data = null)
        {
            WriteText(message, data, LogType.FATAL);
        }

        private void WriteText(string message, object data = null, LogType type = LogType.INFO)
        {
            var trace = string.IsNullOrEmpty(this.Trace) ? "" : " [" + this.Trace + "]";
            var text = DateTime.Now.ToString() + trace;
            text = text + " " + type;
            text = text + " " + message;
            if (data != null)
                text = text + " " + JsonConvert.SerializeObject(data, Formatting.Indented);
            
            Console.WriteLine(text);
        }
    }
}
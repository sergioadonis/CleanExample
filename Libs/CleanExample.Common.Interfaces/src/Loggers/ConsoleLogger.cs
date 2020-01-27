using System;
// using System.Text.Json;
// using System.Text.Json.Serialization;

namespace CleanExample.Common.Interfaces.Loggers
{
    public class ConsoleLogger : ILogger
    {
        private enum LogType 
        {
            DEBUG,
            INFO,
            WARN,
            ERROR,
            FATAL
        }
        
        string traceId;
        
        public ConsoleLogger() { }
        
        public ConsoleLogger(string traceId)
        {
            this.traceId = traceId;
        }
        
        public void Debug(object message)
        {
            WriteText(message, LogType.DEBUG);
        }
        
        public void Info(object message)
        {
            WriteText(message, LogType.INFO);
        }
        
        public void Warn(object message)
        {
            WriteText(message, LogType.WARN);
        }
        
        public void Error(object message)
        {
            WriteText(message, LogType.ERROR);
        }
        
        public void Fatal(object message)
        {
            WriteText(message, LogType.FATAL);
        }
        
        private void WriteText(object message, LogType type)
        {
            var trace = string.IsNullOrEmpty(this.traceId) ? "" : " [" + this.traceId + "]";
            var text = DateTime.Now.ToString() + trace;
            
            text = $"{text} {type} {message.ToString()}";
            
            Console.WriteLine(text);
        }
    }
}
using CleanExample.Common.Services.Loggers;
using Newtonsoft.Json;
using System;

namespace CleanExample.Common.Services.Mocks.Loggers
{
    public class MockLogger : ILogger
    {
        private string _timestamp { get; }

        public MockLogger()
        {
            _timestamp = DateTime.Now.ToFileTime().ToString(); // DateTime.Now.Ticks.ToString();
        }

        private void WriteText(string text)
        {
            // Check if Console, EventLog, File or Database is able
            Console.WriteLine(text);
        }

        public void Log(string message, object data = null, LogType type = LogType.INFO)
        {
            // Check if type is able level
            var text = $"{DateTime.Now.ToString()} [{_timestamp}] {type} {message}";

            if (data != null)
                text = $"{text} {JsonConvert.SerializeObject(data, Formatting.Indented)}";

            WriteText(text);
        }
    }

}
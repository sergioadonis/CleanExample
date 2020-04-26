using System.Text.Json;
using CleanExample.Core.Common.Loggers;
using Xunit.Abstractions;

namespace CleanExample.Test.Products.MockServices.Loggers
{
    public class TestOutputLogger : ILogger
    {
        private readonly ITestOutputHelper _outputHelper; // To use when XUnit run tests

        public TestOutputLogger(ITestOutputHelper testOutputHelper)
        {
            _outputHelper = testOutputHelper;
        }

        private void WriteText(string text)
        {
            // TODO: Check if Console, EventLog, File or Database is able
            _outputHelper.WriteLine(text);
        }

        public void Log(string message, object data = null, LogType type = LogType.Info)
        {
            // TODO: Check if type is able level
            var text = $"{type} {message}";

            if (data != null)
                text = $"{text} {JsonSerializer.Serialize(data, new JsonSerializerOptions() {WriteIndented = true})}";

            WriteText(text);
        }
    }
}
using Framework.Logging;

namespace Framework.Specflow.Logging
{
    public class Log4netTraceListener : TechTalk.SpecFlow.Tracing.ITraceListener
    {
        public void WriteTestOutput(string message)
        {
            Logger.Info(message);
        }

        public void WriteToolOutput(string message)
        {
            Logger.Info(message);
        }
    }
}

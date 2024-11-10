using Framework.Logging;
using System;
using System.Diagnostics;
using System.Threading;

namespace Framework
{
    public class TestElementBase
    {
        public const int DEFAULT_TIMEOUT = 180;

        protected string GetContext()
        {
            string context = "";
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame[] stackFrames = stackTrace.GetFrames();

                foreach (StackFrame stackFrame in stackFrames)
                {
                    var method = stackFrame.GetMethod();
                    if (method.IsAssembly)
                    {
                        break;
                    }
                    var type = method.DeclaringType;
                    var assembly = type.Assembly.GetName().Name;

                    if (!assembly.StartsWith("Ensek.Framework"))
                    {
                        context = $"{type.Name}.{method.Name}";
                        break;
                    }
                }

            }
            catch { }
            return context;
        }

        public void Wait(Func<bool> condition, int timeOutInSeconds = DEFAULT_TIMEOUT, string context = null)
        {
            if (context == null)
            {
                context = GetContext();
            }

            context = context == null ? "" : $", {context}";

            Logger.Debug($"Start wait{context}");

            var wrappedCondition = WrapCondition(condition);

            DateTime start = DateTime.Now;

            var timeout = TimeSpan.FromSeconds(timeOutInSeconds);

            while (true)
            {

                if (wrappedCondition())
                {
                    break;
                }

                if (DateTime.Now.Subtract(start) > timeout)
                {
                    throw new TimeoutException("Timeout waiting for condition to be met");
                }

                Thread.Sleep(100);

            }

            Logger.Debug($"End wait{context}");
        }

        protected Func<bool> WrapCondition(Func<bool> condition)
        {
            return () =>
            {
                bool result = false;
                try
                {
                    result = condition();
                    Logger.Debug($"Condition result: {result}");
                }
                catch (Exception e)
                {
                    var ex = e.ToString();
                    Logger.Info(ex);
                }
                return result;
            };
        }
    }
}

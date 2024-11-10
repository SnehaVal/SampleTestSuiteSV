using Framework.Logging;
using OpenQA.Selenium;
using System;

namespace Framework.Selenium.Activities
{
    public class JQuery
    {
        public Func<IWebDriver, bool> Finishes = (IWebDriver driver) =>
        {
            try
            {
                bool isJqueryCallDone = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0");
                if (!isJqueryCallDone) Logger.Debug("JQuery call is in Progress");
                return isJqueryCallDone;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("jQuery is not defined"))
                {
                    return false;
                }
                throw;
            }
        };

    }
}

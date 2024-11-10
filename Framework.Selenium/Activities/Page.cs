using Framework.Logging;
using OpenQA.Selenium;
using System;

namespace Framework.Selenium.Activities
{
    public class Page
    {
        public Func<IWebDriver, bool> Loads = (IWebDriver driver) =>
        {
            bool isPageLoaded = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
            if (!isPageLoaded)
                Logger.Debug("Document is loading");
            return isPageLoaded;
        };
    }
}

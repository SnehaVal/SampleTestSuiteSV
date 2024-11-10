using Framework.Logging;
using OpenQA.Selenium;
using System;

namespace Framework.Selenium.Activities
{
    public class DocumentIs
    {
        public Func<IWebDriver, bool> Visible = (IWebDriver driver) =>
        {
            bool isDocVisible = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.visibilityState").Equals("visible");
            if (!isDocVisible)
                Logger.Info("Document is not yet visible");
            return isDocVisible;
        };
    }
}

using BoDi;
using Framework.Logging;
using Framework.Selenium.Activities;
using Framework.Selenium.Components;
using Framework.Specflow.Context;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Framework.Selenium.Extensions
{
    public class SeleniumBase : ContextBase
    {
        public IWebDriver Driver { get; private set; }
        public IObjectContainer Container { get; private set; }

        public SeleniumBase(IObjectContainer container) : base(container)
        {
            Container = container;
            Driver = container.Resolve<IWebDriver>();
        }

        public void Wait(Func<IWebDriver, bool> condition, int timeoutInSeconds = DEFAULT_TIMEOUT, string context = null)
        {
            if (context == null)
            {
                context = GetContext();
            }

            context = context == null ? "" : $", {context}";

            Logger.Debug($"Start wait{context}");
            WebDriverWait waitForElement = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            var wrappedCondition = WrapDriverCondition(condition);
            waitForElement.Until(wrappedCondition);
            Logger.Debug($"End wait{context}");
        }

        protected Func<IWebDriver, bool> WrapDriverCondition(Func<IWebDriver, bool> condition)
        {
            return (IWebDriver driver) =>
            {
                bool result = false;
                try
                {
                    result = condition(driver);
                    Logger.Debug($"Condition result: {result}");
                }
                catch (Exception e)
                {
                    Logger.Info(e.Message);
                }
                return result;
            };
        }

        #region Element methods

        public void Click(IWebElement element)
        {
            click(element, false);
        }

        void click(IWebElement element, bool scrolled)
        {
            try
            {
                Wait(Until.Element(element).Is.Displayed);
                Wait(Until.Element(element).Is.Clickable);
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                if (!scrolled)
                {
                    ScrollTo(element);
                    click(element, true);
                    return;
                }
                throw;
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is ElementClickInterceptedException && !scrolled)
                {
                    ScrollTo(element);
                    click(element, true);
                    return;
                }
                throw;
            }
        }

        public void ScrollTo(IWebElement element)
        {
            var xPosition = element.Location.X;
            var yPosition = element.Location.Y - 100;
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);

            IJavaScriptExecutor ex = (IJavaScriptExecutor)Driver;
            ex.ExecuteScript(js);
        }
        #endregion
    }
}

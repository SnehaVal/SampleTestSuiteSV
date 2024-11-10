using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Selenium.Activities
{
    public class ElementIs
    {
        object _element;
        internal ElementIs(object element)
        {
            _element = element;
        }

        public Func<IWebDriver, bool> Clickable
        {
            get
            {

                return Condition(_element, (IWebDriver driver, IWebElement element) => SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null);
            }
        }
        public Func<IWebDriver, bool> Displayed
        {
            get
            {
                return Condition(_element, (IWebDriver driver, IWebElement element) => element.Displayed);
            }
        }

        Func<IWebDriver, bool> Condition(object element, Func<IWebDriver, IWebElement, bool> condition)
        {
            if (element is IWebElement)
            {
                return (IWebDriver driver) => condition(driver, (IWebElement)element);
            }

            if (element is IList<IWebElement>)
            {
                return (IWebDriver driver) => condition(driver, ((IList<IWebElement>)element).FirstOrDefault());
            }

            throw new NotImplementedException();
        }
    }
}

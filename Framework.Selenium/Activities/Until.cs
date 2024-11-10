using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Framework.Selenium.Activities
{
    public static class Until
    {
        public static Document Document => new Document();
        public static JQuery JQuery => new JQuery();
        public static Page Page => new Page();
        public static Element Element(IWebElement element) => new Element(element);
        public static Element Element(IList<IWebElement> elementList) => new Element(elementList);

        public static Func<IWebDriver, bool> Condition(Func<IWebDriver, bool> condition)
            => (IWebDriver driver) => condition(driver);

    }
}

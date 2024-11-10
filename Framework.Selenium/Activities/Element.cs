using OpenQA.Selenium;
using System.Collections.Generic;

namespace Framework.Selenium.Activities
{
    public class Element
    {
        object _element;
        internal Element(IWebElement element)
        {
            _element = element;
        }
        internal Element(IList<IWebElement> elementList)
        {
            _element = elementList;
        }
        public ElementIs Is => new ElementIs(_element);
        public ElementAttribute Attribute(string name) => new ElementAttribute(_element, name);

    }
}

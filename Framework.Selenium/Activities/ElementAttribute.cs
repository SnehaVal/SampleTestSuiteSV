using OpenQA.Selenium;
using System;

namespace Framework.Selenium.Activities
{
    public class ElementAttribute
    {
        IWebElement _element;
        string _attributeName;

        public ElementAttribute(object element, string name)
        {
            if (!(element is IWebElement))
            {
                throw new NotSupportedException("Attribute conditions only supported for single elements");
            }
            _element = (IWebElement)element;
            _attributeName = name;
        }
        public Func<IWebDriver, bool> Equals(string attributeVal)
        {
            return (IWebDriver driver) => _element.GetAttribute(_attributeName).Equals(attributeVal);
        }
    }
}

using OpenQA.Selenium;

namespace Framework.Selenium.Components
{
    public interface IPageComponent
    {
        IWebDriver Driver { get; }
    }
}

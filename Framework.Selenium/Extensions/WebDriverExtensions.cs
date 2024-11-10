using OpenQA.Selenium;

namespace Framework.Selenium.Extensions
{
    public static class WebDriverExtensions
    {
        public static void GoTo(this IWebDriver driver, string url)
        {
            driver.Url = url;
        }
    }
}

using BoDi;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Framework.Selenium.Pages
{
    public class PageFactoryBase
    {
        IObjectContainer _objectContainer;
        IWebDriver _driver;

        public PageFactoryBase(IObjectContainer container)
        {
            this._objectContainer = container;
            _driver = _objectContainer.Resolve<IWebDriver>();
        }
        protected T GetPage<T>() where T : PageBase
        {
            var t = typeof(T);

            var page = _objectContainer.Resolve<T>();

            page.Factory = this;

            PageFactory.InitElements(_driver, page);

            return page;
        }

    }
}

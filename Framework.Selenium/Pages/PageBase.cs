using BoDi;
using Framework.Selenium.Extensions;

namespace Framework.Selenium.Pages
{
    public class PageBase : SeleniumBase
    {
        public PageBase(IObjectContainer container) : base(container) { }

        internal PageFactoryBase Factory;
    }
}

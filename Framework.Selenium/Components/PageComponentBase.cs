using BoDi;
using Framework.Selenium.Extensions;
using SeleniumExtras.PageObjects;

namespace Framework.Selenium.Components
{
    public class PageComponentBase : SeleniumBase, IPageComponent
    {
        public PageComponentBase(IObjectContainer container) : base(container)
        {
            PageFactory.InitElements(Driver, this);
        }

    }
}

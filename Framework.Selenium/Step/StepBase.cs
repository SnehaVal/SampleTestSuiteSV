using BoDi;
using Framework.Selenium.Extensions;
using Framework.Selenium.Pages;

namespace Framework.Selenium.Step
{
    public class StepBase<TPageFactory> : SeleniumBase, IContainsDriver where TPageFactory : PageFactoryBase
    {
        public TPageFactory Pages { get; private set; }

        public StepBase(IObjectContainer container, TPageFactory pageFactory) : base(container)
        {
            Pages = pageFactory;
        }
    }
}

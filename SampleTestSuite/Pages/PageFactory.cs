using BoDi;
using Framework.Selenium.Pages;

namespace SampleTestSuite.Pages
{
    public class PageFactory : PageFactoryBase
    {
        public PageFactory(IObjectContainer container) : base(container) { }

        public LandingPage LandingPage => GetPage<LandingPage>();

    }
}

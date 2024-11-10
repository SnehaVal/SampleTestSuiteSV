using BoDi;
using Framework.Selenium.Pages;
using SampleTestSuite.Pages;

namespace SampleTestSuite.Steps
{
    public class PageFactory : PageFactoryBase
    {
        public PageFactory(IObjectContainer container) : base(container) { }

        public LandingPage LandingPage => GetPage<LandingPage>();

    }
}

using BoDi;
using Framework.Selenium.Hooks;
using TechTalk.SpecFlow;

namespace SampleTestSuite.Hooks
{
    [Binding,
        Scope(Feature = "UTTests"),
        Scope(Feature = "APITests")]
    public class Hooks : HooksBase
    {
        public Hooks(IObjectContainer container) : base(container) { }
    }
}

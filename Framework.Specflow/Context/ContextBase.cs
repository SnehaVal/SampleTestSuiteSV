using BoDi;
using TechTalk.SpecFlow;

namespace Framework.Specflow.Context
{
    public class ContextBase : TestElementBase
    {
        public FeatureContext FeatureContext { get; private set; }
        public ScenarioContext ScenarioContext { get; private set; }

        public ContextBase(IObjectContainer container)
        {
            FeatureContext = container.Resolve<FeatureContext>();
            ScenarioContext = container.Resolve<ScenarioContext>();
        }

    }
}

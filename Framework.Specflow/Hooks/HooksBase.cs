using BoDi;
using Framework.Logging;
using TechTalk.SpecFlow;

namespace Framework.Specflow.Hooks
{
    public class HooksBase
    {
        protected IObjectContainer Container { get; private set; }

        public HooksBase(IObjectContainer container)
        {
            Container = container;
        }

        [BeforeScenario]
        public virtual void BeforeScenario()
        {

            var featureContext = Container.Resolve<FeatureContext>();
            var scenarioContext = Container.Resolve<ScenarioContext>();

            Logger.Info("------------------------------------------------------------------------------");
            Logger.Info("FEATURE  : " + featureContext.FeatureInfo.Title);
            Logger.Info("SCENARIO : " + scenarioContext.ScenarioInfo.Title);
            Logger.Info("------------------------------------------------------------------------------");
        }

        [AfterScenario]
        public virtual void AfterScenario()
        {
            var scenarioContext = Container.Resolve<ScenarioContext>();
        }
    }
}

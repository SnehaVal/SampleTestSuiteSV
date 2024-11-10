using BoDi;
using Framework.Selenium.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Configuration;
using System.IO;
using TechTalk.SpecFlow;
using s = Framework.Specflow.Hooks;

namespace Framework.Selenium.Hooks
{
    public class HooksBase : s.HooksBase
    {
        public IWebDriver Driver { get; private set; }

        public HooksBase(IObjectContainer container) : base(container) { }

        public override void BeforeScenario()
        {
            var scenarioContext = Container.Resolve<ScenarioContext>();

            var webDriverConfiguration = (WebDriverConfigurationSection)ConfigurationManager.GetSection("MTFSelenium");

            string browserName = webDriverConfiguration.BrowserName;

            switch (browserName)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    foreach (var argument in webDriverConfiguration.DriverArguments)
                    {
                        options.AddArgument(((DriverArgument)argument).Value);
                    }
                    Driver = new ChromeDriver(options);
                    break;
                case "Edge":
                    Driver = new EdgeDriver();
                    break;
                default:
                    throw new Exception("Invalid Browser: " + browserName);
            }
            Container.RegisterInstanceAs(Driver);
            base.BeforeScenario();
        }

        public override void AfterScenario()
        {
            var scenarioContext = Container.Resolve<ScenarioContext>();
            var file = $"{scenarioContext.ScenarioInfo.Title}.jpg";
            Driver.Quit();
            base.AfterScenario();
        }
    }
}

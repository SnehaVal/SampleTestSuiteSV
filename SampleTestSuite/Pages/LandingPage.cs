using BoDi;
using Framework.Selenium.Extensions;
using Framework.Selenium.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SampleTestSuite.Pages
{
    public class LandingPage : PageBase
    {
        public LandingPage(IObjectContainer container) : base(container) { }
        #region IWebElements
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LogInLink { get; set; }
        #endregion
        #region Methods
        public void ClickOnLogIn()
        {
            Driver.GoTo("https://ensekautomationcandidatetest.azurewebsites.net/");
            Click(LogInLink);
        }
        #endregion

    }
}

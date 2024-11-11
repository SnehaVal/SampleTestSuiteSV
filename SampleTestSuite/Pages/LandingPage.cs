using BoDi;
using Framework.Selenium.Extensions;
using Framework.Selenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace SampleTestSuite.Pages
{
    public class LandingPage : PageBase
    {
        public LandingPage(IObjectContainer container) : base(container) { }
        #region IWebElements
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement LogInLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Buy energy »')]")]
        public IWebElement BuyEnergyLink { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]/input")]
        public IWebElement GasQuantity { get; set; }


        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]/input")]
        public IWebElement BuyGasLink { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/h2")]
        public IWebElement SaleConfirmationText { get; set; }

        #endregion
        #region Methods
        public void ClickOnLogIn()
        {
            Driver.GoTo("https://ensekautomationcandidatetest.azurewebsites.net/");
            Click(LogInLink);           
        }

        public void OpenLandingPage()
        {
            Driver.GoTo("https://ensekautomationcandidatetest.azurewebsites.net/");

        }

        public void ClickOnBuyEnergy()
        {
            Click(BuyEnergyLink);
        }
       
        public void EnterQuantityForGas(string quantity)
        {
            Thread.Sleep(1000);
            GasQuantity.Clear();
            GasQuantity.SendKeys(quantity);
        }

        public void BuyGas()
        {
            Click(BuyGasLink);
        }

        public void AssertPurchaseIsSuccessful()
        {
            Thread.Sleep(1000);
            Assert.That(SaleConfirmationText.Text.Equals("Sale Confirmed!"));
        }

        #endregion

    }
}

using SampleTestSuite.Pages;
using TechTalk.SpecFlow;
using BoDi;
using Framework.Selenium.Step;
using Framework.Specflow.Extensions;

namespace SampleTestSuite.Steps
{
    [Binding]
    public sealed class UISteps : StepBase<PageFactory>
    {
        public UISteps(IObjectContainer container, PageFactory pageFactory) : base(container, pageFactory) { }

        [Given(@"the landing page is loaded")]
        public void GivenTheLandingPageIsLoaded()
        {
            Pages.LandingPage.OpenLandingPage();
        }

        [Given(@"the buy energy link is selected")]
        public void GivenTheBuyEnergyLinkIsSelected()
        {
            Pages.LandingPage.ClickOnBuyEnergy();
        }

        [When(@"I enter the quantity for gas and click on Buy")]
        public void WhenIEnterTheQuantityForGasAndClickOnBuy(Table table)
        {
            var details = table.ToDictionary();
            Pages.LandingPage.EnterQuantityForGas(details["quantity"]);
            Pages.LandingPage.BuyGas();
        }

        [Then(@"the purchase is successful")]
        public void ThenThePurchaseIsSuccessful()
        {
            Pages.LandingPage.AssertPurchaseIsSuccessful();
        }

    }
}

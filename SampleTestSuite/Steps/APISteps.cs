using BoDi;
using Framework.Logging;
using Framework.Selenium.Step;
using Framework.WebRequests;
using Framework.WebRequests.ClassModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SampleTestSuite.Steps
{
    [Binding]
    public sealed class APISteps : StepBase<PageFactory>
    {
        public APISteps(IObjectContainer container, PageFactory pageFactory) : base(container, pageFactory) { }

        [Given(@"the user is logged on using API")]
        public void GivenTheUserIsLoggedOnUsingAPI()
        {
            var accessToken = ExexuteRestRequests.LogOnToAccount().access_token;
            ScenarioContext.Add("AccessToken", accessToken);
            Logger.Info("Access Token is : " + accessToken);
        }

        [When(@"the test data is reset")]
        [Given(@"the test data is reset")]
        public void GivenTheTestDataIsReset()
        {
            var status = ExexuteRestRequests.ResetTheData().message;
            ScenarioContext.Add("ResetResponseMessage", status);

        }

        [Then(@"the response is returned as success")]
        public void ThenTheResponseIsReturnedAsSuccess()
        {
            Assert.That(ScenarioContext.Get<string>("ResetResponseMessage").Equals("Success"), Is.True);
        }

        [Given(@"the energy details is requested using API")]
        [When(@"the energy details is requested using API")]
        public void WhenTheEnergyDetailsIsRequestedUsingAPI()
        {
            var energyDetails = ExexuteRestRequests.GetEnergyDetails();
            ScenarioContext.Add("EnergyDetails", energyDetails);
        }

        [Given(@"the energy details is retrieved successfully")]
        [Then(@"the energy details is retrieved successfully")]
        public void ThenTheEnergyDetailsIsRetrievedSuccessfully()
        {
            var energyDetails = ScenarioContext.Get<Dictionary<string, EnergyDetails>>("EnergyDetails");
            foreach (var energyType in energyDetails)
            {
                Logger.Info($"{energyType.Key} : \n");
                var details = energyType.Value;
                Logger.Info($"EnergyId : {details.energy_id} \n");
                Logger.Info($"UnitType : {details.unit_type} \n");
                Logger.Info($"PricePerUnit : {details.price_per_unit}  \n");
                Logger.Info($"Quantity of Units : {details.quantity_of_units}");
            }
        }

        [Given(@"the (.*) of (.*) is purchased using API")]
        [When(@"the (.*) of (.*) is purchased using API")]
        public void WhenTheEnergyIsPurchasedUsingAPI(string energyType, int quantity)
        {
            int energyId = 0;
            foreach (var fuel in ScenarioContext.Get<Dictionary<string, EnergyDetails>>("EnergyDetails"))
            {
                if (fuel.Key.Equals(energyType))
                {
                    energyId = fuel.Value.energy_id;
                    break;
                }
            }
            var response = ExexuteRestRequests.BuyEnergy(energyId, quantity);
            ScenarioContext["message"] = response.message;
        }

        [Then(@"the purchased should be successful")]
        public void ThenThePurchasedShouldBeSuccessful()
        {
            var expectedMessageString = "You have purchased";
            Assert.That(ScenarioContext.Get<string>("message").Contains(expectedMessageString), ScenarioContext.Get<string>("message"));
        }

        [Given(@"the order details is requested using API")]
        [When(@"the order details is requested using API")]
        public void WhenTheOrderDetailsIsRequestedUsingAPI()
        {
            var response = ExexuteRestRequests.GetOrderDetails();
            ScenarioContext.Add("OrderDetails", response);
        }

        [Given(@"the order details is retrieved successfully")]
        [Then(@"the order details is retrieved successfully")]
        public void ThenTheOrderDetailsIsRetrievedSuccessfully()
        {
            bool isOrderCreated = false;
            var orderList = ScenarioContext.Get<List<OrderDetailsResponse>>("OrderDetails");
            foreach (var orderItem in orderList)
            {
                if (ScenarioContext.Get<string>("message").Contains(orderItem.Id))
                {
                    isOrderCreated = true;
                    break;
                }
            }
            Assert.That(isOrderCreated.Equals(true), "Order is not created");
        }

        [Then(@"the number of orders created prior to the current day is calculated")]
        public void ThenTheNumberOfOrdersCreatedPriorToTheCurrentDayIsCalculated()
        {
            var orderList = ScenarioContext.Get<List<OrderDetailsResponse>>("OrderDetails");
            int count = 0;
            var currentDate = DateTime.Today;

            foreach (var orderItem in orderList)
            {
                DateTime createdTime;
                DateTime.TryParseExact(orderItem.time, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdTime);
                if (createdTime < currentDate)
                {
                    count++;
                }
            }
            Logger.Info($"The number of orders created prior to the current date is {count}");
            ScenarioContext.Add("NumberOfOrdersCreatedPriorToCurrentDay", count);
        }

    }
}

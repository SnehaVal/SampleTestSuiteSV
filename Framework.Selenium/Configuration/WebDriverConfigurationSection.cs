using System.Configuration;

namespace Framework.Selenium.Configuration
{
    public class WebDriverConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("browserName", IsRequired = true)]
        public string BrowserName
        {
            get
            {
                return (string)base["browserName"];
            }
        }

        [ConfigurationProperty("DriverArguments", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DriverArgumentsCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public DriverArgumentsCollection DriverArguments
        {
            get
            {
                return (DriverArgumentsCollection)base["DriverArguments"];
            }
        }

        [ConfigurationProperty("screenShotPath", IsRequired = false)]
        public string ScreenShotPath
        {
            get
            {
                return (string)base["browserName"];
            }
        }

    }
}

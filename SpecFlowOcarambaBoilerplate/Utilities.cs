using Ocaramba;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowOcarambaBoilerplate
{
    internal static class Utilities
    {
        internal static IWebDriver GetWebDriver(this ScenarioContext scenarioContext)
        {
            var driverContext = scenarioContext.Get<DriverContext>("DriverContext");
            return driverContext.Driver;
        }
    }
}

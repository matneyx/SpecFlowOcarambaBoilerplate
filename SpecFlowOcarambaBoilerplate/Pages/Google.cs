using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Ocaramba.Extensions;
using System.Linq;

namespace SpecFlowOcarambaBoilerplate.Pages
{
    public class Google
    {
        private readonly IWebDriver driver;

        public Google(ScenarioContext scenarioContext)
        {
            this.driver = scenarioContext.GetWebDriver();
        }

        internal void GoToGoogle()
        {
            this.driver.NavigateTo(new Uri("http://www.google.com"));
        }

        internal void TypeIntoSearchBar(string searchString)
        {
            var searchBar = GetSearchBar();

            searchBar.SendKeys(searchString);
        }

        private IWebElement GetSearchBar() => this.driver.FindElement(By.Name("q"));

        internal void HitEnterInSearchBar()
        {
            var searchBar = GetSearchBar();

            searchBar.SendKeys(Keys.Enter);
        }

        internal string GetFirstSearchResultText() =>
            this.driver.FindElements(By.ClassName("g")).First().Text;
    }
}

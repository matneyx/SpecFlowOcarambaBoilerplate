using OpenQA.Selenium;
using Should;
using SpecFlowOcarambaBoilerplate.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowOcarambaBoilerplate.Steps
{
    [Binding]
    public class GoogleSteps
    {
        private readonly Google google;
        private IWebDriver driver;

        public GoogleSteps(Google google, ScenarioContext scenarioContext)
        {
            this.driver = scenarioContext.GetWebDriver();
            this.google = google;
        }

        [Given(@"I have navigated to Google")]
        public void GivenIHaveNavigatedToGoogle()
        {
            this.google.GoToGoogle();
        }

        [Given(@"I have entered ""(.*)"" into the search bar")]
        public void GivenIHaveEnteredIntoTheSearchBar(string p0)
        {
            this.google.TypeIntoSearchBar(p0);
        }

        [When(@"I hit Enter")]
        public void WhenIHitEnter()
        {
            this.google.HitEnterInSearchBar();
        }

        [Then(@"I should be redirected to the Search Results page")]
        public void ThenIShouldBeRedirectedToTheSearchResultsPage()
        {
            this.driver.Url.ShouldContain("search");
        }

        [Then(@"the first result should be www\.wikipedia\.org")]
        public void ThenTheFirstResultShouldBeWww_Wikipedia_Org()
        {
            this.google.GetFirstSearchResultText().ShouldContain("www.wikipedia.org");
        }
    }
}

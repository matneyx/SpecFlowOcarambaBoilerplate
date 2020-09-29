using OpenQA.Selenium;
using Shouldly;
using TechTalk.SpecFlow;

namespace SpecFlowOcarambaBoilerplate.Steps
{
    [Binding]
    public class GoogleSteps
    {
        private readonly IWebDriver driver;
        private readonly Pages.Google google;

        public GoogleSteps(Pages.Google google, ScenarioContext scenarioContext)
        {
            driver = scenarioContext.GetWebDriver();
            this.google = google;
        }

        [Given(@"I have navigated to Google")]
        public void GivenIHaveNavigatedToGoogle()
        {
            google.GoToGoogle();
        }

        [Given(@"I have entered ""(.*)"" into the search bar")]
        public void GivenIHaveEnteredIntoTheSearchBar(string p0)
        {
            google.TypeIntoSearchBar(p0);
        }

        [When(@"I hit Enter")]
        public void WhenIHitEnter()
        {
            google.HitEnterInSearchBar();
        }

        [Then(@"I should be redirected to the Search Results page")]
        public void ThenIShouldBeRedirectedToTheSearchResultsPage()
        {
            driver.Url.ShouldContain("search");
        }

        [Then(@"the first result should be www\.wikipedia\.org")]
        public void ThenTheFirstResultShouldBeWww_Wikipedia_Org()
        {
            google.GetFirstSearchResultText().ShouldContain("www.wikipedia.org");
        }
    }
}

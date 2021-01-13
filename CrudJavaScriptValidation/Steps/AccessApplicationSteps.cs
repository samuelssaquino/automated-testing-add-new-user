using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace CrudJavaScriptValidation.Steps
{
    [Binding]
    public class AccessApplicationSteps
    {
        private readonly IWebDriver _webDriver;

        public AccessApplicationSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I access the page ""(.*)""")]
        public void GivenIAccessThePage(string homepage)
        {
            _webDriver.Url = $"{homepage}";
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string title)
        {
            Assert.Equal(title, _webDriver.Title);
        }
    }
}

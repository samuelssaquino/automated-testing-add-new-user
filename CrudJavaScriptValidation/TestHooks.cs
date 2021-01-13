using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace TestJS
{
    [Binding]
    class TestHooks
    {
        [Before]
        public void CreateWebDriver(ScenarioContext context)
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            IWebDriver driver = new ChromeDriver(options);
            context["WEB_DRIVER"] = driver;
        }

        [After]
        public void CloseWebDriver(ScenarioContext context)
        {
            //var driver = context["WEB_DRIVER"] as IWebDriver;
            //driver.Quit();
        }
    }
}

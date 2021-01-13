using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace CrudJavaScriptValidation.Steps
{
    [Binding]
    public class AddUserSteps
    {
        private readonly IWebDriver _webDriver;

        public AddUserSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I check the ""(.*)"" page")]
        public void GivenICheckThePage(string msg)
        {
            String userReg = _webDriver.FindElement(By.XPath("//h2[contains(text(),'USER REGISTRATION')]")).Text;
            Assert.Equal(userReg, msg);
        }

        [When(@"I click the save button")]
        public void WhenIClickTheSaveButton()
        {
            IWebElement elementBtnSave = _webDriver.FindElement(By.Id("btnSave"));
            elementBtnSave.Click();
        }

        [Then(@"I click on the add user button")]
        public void ThenIClickOnTheAddUserButton()
        {
            Thread.Sleep(2000);
            IWebElement elementBtn = _webDriver.FindElement(By.Id("btnAddUser"));
            elementBtn.Click();
        }

        [Then(@"I verify that the modal register is displayed")]
        public void ThenIVerifyThatTheModalRegisterIsDisplayed()
        {
            Thread.Sleep(3000);
            bool elementRegisterModal = _webDriver.FindElement(By.Id("modalRegisterLabel")).Displayed;
            Assert.True(elementRegisterModal);
        }

        [Then(@"I enter the field first name with ""(.*)""")]
        public void ThenIEnterTheFieldFirstNameWith(string firstName)
        {
            _webDriver.FindElement(By.Id("firstName")).SendKeys(firstName);
        }

        [Then(@"I enter the field last name with ""(.*)""")]
        public void ThenIEnterTheFieldLastNameWith(string lastName)
        {
            _webDriver.FindElement(By.Id("lastName")).SendKeys(lastName);
        }

        [Then(@"I enter the other fields with valid data")]
        public void ThenIEnterTheOtherFieldsWithValidData()
        {
            //Select Title
            IWebElement TitleDropDownElement = _webDriver.FindElement(By.Id("title"));
            SelectElement SelectAnTitle = new SelectElement(TitleDropDownElement);
            SelectAnTitle.SelectByText("Dr.");

            //Enter Email
            _webDriver.FindElement(By.Id("email")).SendKeys("sam@sam.com");

            //Enter Email Confirm
            _webDriver.FindElement(By.Id("cemail")).SendKeys("sam@sam.com");

            //Enter Password
            _webDriver.FindElement(By.Id("password")).SendKeys("123456");

            //Enter Password Confirm
            _webDriver.FindElement(By.Id("cpassword")).SendKeys("123456");

            //Select Sex
            _webDriver.FindElement(By.XPath("//label[contains(text(),'Male')]")).Click();

            //Enter Date of Birth
            _webDriver.FindElement(By.Id("dtBirth")).SendKeys("10/01/1990");

            //Select nº of childern
            IWebElement ChildrenDropDownElement = _webDriver.FindElement(By.Id("children"));
            SelectElement SelectAnChildren = new SelectElement(ChildrenDropDownElement);
            SelectAnChildren.SelectByText("3");

            //Select Country
            IWebElement CountryDropDownElement = _webDriver.FindElement(By.Id("country"));
            SelectElement SelectAnCountry = new SelectElement(CountryDropDownElement);
            SelectAnCountry.SelectByText("Canada");

            //Enter Phone
            _webDriver.FindElement(By.Id("phone")).SendKeys("+1 23 56 89 78");

            //Select Terms of Service
            _webDriver.FindElement(By.XPath("//body/div[@id='modalRegister']/div[1]/div[1]/div[2]/div[1]/div[1]/form[1]/div[4]/label[1]")).Click();
        }

        [Then(@"The application should display the message ""(.*)""")]
        public void ThenTheApplicationShouldDisplayTheMessage(string ExpectedMsg)
        {
            IAlert alert = _webDriver.SwitchTo().Alert();
            String actualMsg = alert.Text;
            Assert.Equal(actualMsg, ExpectedMsg);
            alert.Accept();
        }

        [Then(@"The application should display the registered user in the list")]
        public void ThenTheApplicationShouldDisplayTheRegisteredUserInTheList()
        {
            String title = _webDriver.FindElement(By.XPath("//td[contains(text(),'Dr.')]")).Text;
            Assert.NotNull(title);
            Assert.Equal("Dr.", title);

            String firstName = _webDriver.FindElement(By.XPath("//td[contains(text(),'Samuel')]")).Text;
            Assert.NotNull(firstName);
            Assert.Equal("Samuel", firstName);

            String lastName = _webDriver.FindElement(By.XPath("//td[contains(text(),'Aquino')]")).Text;
            Assert.NotNull(lastName);
            Assert.Equal("Aquino", lastName);

            String email = _webDriver.FindElement(By.XPath("//td[contains(text(),'sam@sam.com')]")).Text;
            Assert.NotNull(email);
            Assert.Equal("sam@sam.com", email);

            String dtBirth = _webDriver.FindElement(By.XPath("//td[contains(text(),'1990-01-10')]")).Text;
            Assert.NotNull(dtBirth);
            Assert.Equal("1990-01-10", dtBirth);

            String sex = _webDriver.FindElement(By.XPath("//td[contains(text(),'M')]")).Text;
            Assert.NotNull(sex);
            Assert.Equal("M", sex);

            String children = _webDriver.FindElement(By.XPath("//tbody/tr[@id='rowTable0']/td[7]")).Text;
            Assert.NotNull(children);
            Assert.Equal("3", children);

            String country = _webDriver.FindElement(By.XPath("//td[contains(text(),'Canada')]")).Text;
            Assert.NotNull(country);
            Assert.Equal("Canada", country);

            String phone = _webDriver.FindElement(By.XPath("//td[contains(text(),'+1 23 56 89 78')]")).Text;
            Assert.NotNull(phone);
            Assert.Equal("+1 23 56 89 78", phone);
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LoginInscription.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;

        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html"); }


        [Given(@"I enter username and password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _driver.FindElement(By.Name("UserName")).SendKeys((string)data.UserName);
            _driver.FindElement(By.Name("Password")).SendKeys((string)data.Password);


        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            Thread.Sleep(15000);
            _driver.FindElement(By.Name("Login")).Submit();
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            //to verify if i see the execution automate site
            var element = _driver.FindElement(By.XPath("//h1[contains (text(),'Execute Automation Selenium Test Site')]"));
            Assert.That(element.Text, Is.Not.Null, "Header text not found");

        } 
    }
}

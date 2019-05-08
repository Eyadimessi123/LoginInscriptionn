using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LoginInscription.Steps
{
    [Binding]
    public class UserFormSteps
    { 
         private IWebDriver _driver;
       

        public UserFormSteps(IWebDriver driver)

    {
        _driver =  driver;
    }
    
        [Given(@"I start entering user form details like")]
        public void GivenIStartEnter_driveringUserFormDetailsLike(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _driver.FindElement(By.Id("Initial")).SendKeys((string)data.Initial);
            _driver.FindElement(By.Id("FirstName")).SendKeys((string)data.FirstName);
            _driver.FindElement(By.Id("MiddleName")).SendKeys((string)data.MiddleName);
            Thread.Sleep(2000);
        }
        [Given(@"I click submit button")]
        public void GivenIClickSubmitButton()
        {
            _driver.FindElement(By.Name("Save")).Click();
        }

        [Then(@"I verify the entered user form details in the application database")]
        public void ThenIVerifyTheEnteredUserFormDetailsInTheApplicationDatabase(Table table)
        {
            //Mock data collection
            List<AUTDatabase> mockAUTData = new List<AUTDatabase>()
            {
                new AUTDatabase()
                {
                    FirstName = "Karthik",
                    Initial = "k",
                    MiddleName = "k"
                },
                 new AUTDatabase()
                {
                    FirstName = "Prashanth",
                    Initial = "k",
                    MiddleName = "k"
                }
            };
            //For verification with single row data
            var result = table.FindAllInSet(mockAUTData);
        }

        //[Then(@"I logout of application")]
        //public void ThenILogoutOfApplication()
        //{
        //    ScenarioContext.Current.Pending();
        //}
    }
    public class AUTDatabase
    {
        public string Initial { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }
    }
}

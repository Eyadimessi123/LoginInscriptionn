using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LoginInscription
{[Binding ]
    
    class Hooks 
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        //private RemoteWebDriver _driver;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }




   [BeforeScenario]
        public void Initialize()
        {


            _driver = new FirefoxDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }
        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }
      

    }
 
    }



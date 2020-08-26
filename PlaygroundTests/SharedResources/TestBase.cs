using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Playground.SharedResources.Constants;
using Playground.SharedResources.Helpers;
using System;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Microsoft.Edge.SeleniumTools;

namespace PlaygroundTests.SharedResources
{
    [TestClass]
    public class TestBase
    {
        #region Fields

        public static IWebDriver _webDriver { get; private set; }
        public static TestContext TestContext { get; set; }
        private BrowserHelper _browser;
        private List<string> _commandLineArguments;
        

        #endregion

        #region Test Setup

        /// <summary>
        /// Initializes our Driver and Browser.
        /// Runs before every test for the classes that inherit from TestBase
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            //Sets the driver for the Browser
            InitializeDriver();

            //Sets an instance of browser help class
            _browser = new BrowserHelper(_webDriver);
                        
        }

        #endregion

        #region Test Cleanup

        /// <summary>
        /// Cleans up all our tests by closing the Driver
        /// </summary>
        [TestCleanup]
        public void TestClean()
        {
            // close all the things
            _browser.ShutDown();
        }

        #endregion

        #region Helpers

        private void InitializeDriver()
        {            
            switch (TestEnvironment.DesignatedDriver)
            {
                case "Chrome":

                    new DriverManager().SetUpDriver(new ChromeConfig());

                    //This sets up our browser options
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AcceptInsecureCertificates = true;
                    if (TestEnvironment.IsHeadless == "True"){chromeOptions.AddArguments("--headless");}

                    //This initializes our driver with set options.
                    _webDriver = new ChromeDriver(chromeOptions);
                    _webDriver.Manage().Window.Maximize();

                    break;                                      

                case "Firefox":

                    new DriverManager().SetUpDriver(new FirefoxConfig());
                                       
                    //Sets the IPv6 loopback address. Firefox has a performance issue in .net core. This solves for that.
                    FirefoxDriverService firefoxService = FirefoxDriverService.CreateDefaultService();
                    firefoxService.Host = "::1";

                    //This sets up our browser options
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AcceptInsecureCertificates = true;
                    if (TestEnvironment.IsHeadless == "True") { firefoxOptions.AddArguments("-headless"); }

                    //This initializes our driver with set service and options
                    _webDriver = new FirefoxDriver(firefoxService, firefoxOptions);
                    _webDriver.Manage().Window.Maximize();

                    break;

                case "Edge":

                    new DriverManager().SetUpDriver(new EdgeConfig());

                    //This sets up our browser options
                    var options = new EdgeOptions();
                    options.UseChromium = true;
                    options.AcceptInsecureCertificates = true;
                    if (TestEnvironment.IsHeadless == "True") { options.AddArguments("headless"); }

                    //This initializes our driver with set options
                    _webDriver = new EdgeDriver(options);
                    _webDriver.Manage().Window.Maximize();

                    break;

                default:

                    Console.WriteLine("You must be drunk! You need to specify a designated driver!");
                    break;

                    //TODO - Add support for other browsers:
                    //new ChromeConfig();
                    //new EdgeConfig();
                    //new FirefoxConfig();
                    //new InternetExplorerConfig();
                    //new OperaConfig();
                    //new PhantomConfig();
            }
        }

        private void SetCommandLineArgument(string argument, bool value)
        {
            if (value)
                _commandLineArguments.Add(argument);
            else
                _commandLineArguments.Remove(argument);
        }

        #endregion
    }
}

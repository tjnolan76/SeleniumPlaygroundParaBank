using OpenQA.Selenium;
using System;

namespace Playground.SharedResources.Helpers
{
    public class BrowserHelper
    {
        #region Fields

        private readonly IWebDriver _driver;

        #endregion

        #region Constructors

        public BrowserHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        #endregion

        #region Helpers

        public void TakeScreenshot()
        {
            string dt = DateTime.Now.ToString("yyyy_dd_MMMM_hh_mm_ss_tt");
            try
            {
                System.IO.Directory.CreateDirectory(@"C:\SeleniumTestingScreenshots");
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile(@"C:\SeleniumTestingScreenshots" + "_" + dt + ".Png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool TitleContains(string TitleContains)
            => _driver.Title.Contains(TitleContains);

        public IWebElement GetElementByIdOrNull(string Id)
        {
            try
            {
                var element = _driver.FindElement(By.Id(Id));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IWebElement GetElementByXpathOrNull(string XPath)
        {
            try
            {
                var element = _driver.FindElement(By.XPath(XPath));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IWebElement GetElementByClassNameOrNull(string ClassName)
        {
            try
            {
                var element = _driver.FindElement(By.ClassName(ClassName));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IWebElement GetElementByCssSelecterOrNull(string CssSelector)
        {
            try
            {
                var element = _driver.FindElement(By.CssSelector(CssSelector));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void ShutDown()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
            }


        }

        #endregion

    }
}

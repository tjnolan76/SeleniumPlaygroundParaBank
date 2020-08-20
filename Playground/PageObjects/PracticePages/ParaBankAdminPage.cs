using OpenQA.Selenium;
using Playground.SharedResources.Constants;
using System.Threading;

namespace Playground.PageObjects.PracticePages
{
    public class ParaBankAdminPage
    {
        #region Fields

        private readonly string URL = $"{TestEnvironment.BaseUrl}{UrlFragments.AdminPage}";
        private readonly IWebDriver _driver;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ParaBankAdminPage" /> class.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        public ParaBankAdminPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #endregion

        #region Navigation

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(URL);
        }

        #endregion

        #region User Actions

        //TODO - Remove sleeps.

        public void ClickCleanButton()
        {
            CleanButton.Click();
            Thread.Sleep(2000);
        }

        public void ClickRegisterButton()
        {
            RegisterButton.Click();
        }

        public void ClickLogoutButton()
        {
            LogoutButton.Click();
            Thread.Sleep(500);
            
        }

        #endregion

        #region Elements

        public IWebElement RegisterButton
            => _driver.FindElement(By.XPath("//a[contains(.,'Register')]"));

        public IWebElement LogoutButton
            => _driver.FindElement(By.XPath("//a[contains(., 'Log Out')]"));

        public IWebElement CleanButton
            => _driver.FindElement(By.XPath("//*[@type='submit'][@value='CLEAN']"));

        public IWebElement DbCleanedMsg
            => _driver.FindElement(By.XPath("//*[@id='rightPanel']//*[contains(text(),'Database Cleaned')]"));

        #endregion

    }
}

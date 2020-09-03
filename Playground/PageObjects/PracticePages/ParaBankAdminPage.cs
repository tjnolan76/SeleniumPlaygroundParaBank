using AngleSharp.Common;
using OpenQA.Selenium;
using Playground.SharedResources.Constants;
using System.Threading;

namespace Playground.PageObjects.PracticePages
{
    public class ParaBankAdminPage
    {
        #region Fields

        private readonly string _url = $"{TestEnvironment.BaseUrl}{UrlFragments.AdminPage}";
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
            _driver.Navigate().GoToUrl(_url);
        }

        #endregion

        #region User Actions

        public void ClickCleanButton()
        {
            CleanButton.Click();
        }

        public void ClickRegisterButton()
        {            
            RegisterButton.Click();
        }

        public void ClickLogoutButton()
        {
            LogoutButton.Click();
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

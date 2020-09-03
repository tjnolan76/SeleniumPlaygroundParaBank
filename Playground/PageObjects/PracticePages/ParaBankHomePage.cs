using OpenQA.Selenium;
using Playground.SharedResources.Constants;

namespace Playground.PageObjects.PracticePages
{
    public class ParaBankHomePage
    {
        #region Fields

        private readonly string _url = $"{TestEnvironment.BaseUrl}";
        private readonly IWebDriver _driver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ParaBankHomePage" /> class.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        public ParaBankHomePage(IWebDriver driver)
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

        public void UserLogin(string userName, string password)
        {
            UserNameField.SendKeys(userName);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        #endregion

        #region Elements

        #region Customer Login Elements

        public IWebElement UserNameField
            => _driver.FindElement(By.XPath("//*[@id='loginPanel']//*[@class='login']//*[@name='username']"));

        public IWebElement PasswordField
            => _driver.FindElement(By.XPath("//*[@id='loginPanel']//*[@class='login']//*[@name='password']"));

        public IWebElement LoginButton
            => _driver.FindElement(By.XPath("//*[@id='loginPanel']//*[@class='login']//*[@type='submit']"));

        public IWebElement WelcomeMessage
            => _driver.FindElement(By.XPath("//*[@id='leftPanel'][contains(., 'Welcome')]"));

        public IWebElement ErrorMessage
            => _driver.FindElement(By.XPath("//*[@id='rightPanel']//*[@class='error']"));

        #endregion

        #endregion

    }
}

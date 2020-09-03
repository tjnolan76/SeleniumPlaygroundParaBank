using OpenQA.Selenium;
using Playground.SharedResources.Constants;

namespace Playground.PageObjects.PracticePages
{
    public class ParaBankContactPage
    {
        #region Fields

        private readonly string _url = $"{TestEnvironment.BaseUrl}{UrlFragments.ContactPage}";
        private readonly IWebDriver _driver;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ParaBankAdminPage" /> class.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        public ParaBankContactPage(IWebDriver driver)
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

        #region Elements

        public IWebElement ContactSubmissionResponse
            => _driver.FindElement(By.XPath("//*[@id='rightPanel']/p[2]"));

        public IWebElement Name
            => _driver.FindElement(By.XPath("//*[@id='name']"));

        public IWebElement Email
            => _driver.FindElement(By.XPath("//*[@id='email']"));

        public IWebElement Phone
            => _driver.FindElement(By.XPath("//*[@id='phone']"));

        public IWebElement Message
            => _driver.FindElement(By.XPath("//*[@id='message']"));

        public IWebElement SendButton
            => _driver.FindElement(By.XPath("//*[@id='contactForm']//*[@class='button']"));

        #endregion
    }
}

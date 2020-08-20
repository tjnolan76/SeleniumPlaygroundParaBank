using OpenQA.Selenium;
using Playground.SharedResources.Constants;
using Playground.SharedResources.Helpers;

namespace Playground.PageObjects.PracticePages
{
    public class ParaBankRegisterPage
    {
        #region Fields

        private readonly string URL = $"{TestEnvironment.BaseUrl}{UrlFragments.RegisterPage}";
        private readonly IWebDriver _driver;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ParaBankRegisterPage" /> class.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        public ParaBankRegisterPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        #endregion

        #region Navigation

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(URL);
        }

        #endregion

        #region User Actions

        public void RegisterUser(string FirstName, string LastName, string UserName, string Password)
        {
            FirstNameField.SendKeys(FirstName);
            LastNameField.SendKeys(LastName);
            StreetAddressField.SendKeys(UniversalConstants.StreetAddress);
            CityField.SendKeys(UniversalConstants.City);
            StateField.SendKeys(UniversalConstants.State);
            ZipCodeField.SendKeys(UniversalConstants.ZipCode);
            PhoneNumberField.SendKeys(UniversalConstants.Phone);
            SSNField.SendKeys(UniversalConstants.SSN);
            UserNameField.SendKeys(UserName);
            PasswordField.SendKeys(Password);
            ConfirmPasswordField.SendKeys(Password);

            ClickRegisterButton();
        }

        public void ClickRegisterButton()
        {
            RegisterButton.Click();
        }

        public void Logout()
        {
            LogoutButton.Click();
        }


        #endregion

        #region Elements

        public IWebElement LogoutButton
            => _driver.FindElement(By.XPath("//a[.='Log Out']"));

        public IWebElement AccountCreatedMsg
            => _driver.FindElement(By.XPath("//*[@id='rightPanel']"));

        public IWebElement RegisterButton
            => _driver.FindElement(By.XPath("//*[@class='button'][@value='Register']"));

        public IWebElement FirstNameField
            => _driver.FindElement(By.Id("customer.firstName"));

        public IWebElement LastNameField
            => _driver.FindElement(By.Id("customer.lastName"));

        public IWebElement StreetAddressField
            => _driver.FindElement(By.Id("customer.address.street"));

        public IWebElement CityField
            => _driver.FindElement(By.Id("customer.address.city"));

        public IWebElement StateField
            => _driver.FindElement(By.Id("customer.address.state"));

        public IWebElement ZipCodeField
            => _driver.FindElement(By.Id("customer.address.zipCode"));

        public IWebElement PhoneNumberField
            => _driver.FindElement(By.Id("customer.phoneNumber"));

        public IWebElement SSNField
            => _driver.FindElement(By.Id("customer.ssn"));

        public IWebElement UserNameField
            => _driver.FindElement(By.Id("customer.username"));

        public IWebElement PasswordField
            => _driver.FindElement(By.Id("customer.password"));

        public IWebElement ConfirmPasswordField
            => _driver.FindElement(By.Id("repeatedPassword"));

        #endregion

        #region Actions

        public string WelcomeMessage()
        {
            return AccountCreatedMsg.Text;
        }

        #endregion

    }
}

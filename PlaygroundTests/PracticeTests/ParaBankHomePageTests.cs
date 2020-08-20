using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.PageObjects;
using Playground.PageObjects.PracticePages;
using Playground.SharedResources.Constants;
using Playground.SharedResources.Helpers;
using PlaygroundTests.SharedResources;
using System;

namespace PlaygroundTests.PracticeTests
{
    [TestClass]
    public class ParaBankHomePageTests : TestBase
    {
        #region Fields

        private ParaBankHomePage _paraBankHomePage;
        private BrowserHelper _browser;
        private ParaBankAdminPage _adminPage;
        private ParaBankRegisterPage _registerPage;

        #endregion

        #region Initalization

        [TestInitialize]
        public void TestInitialize()
        {
            _paraBankHomePage = new ParaBankHomePage(_webDriver);
            _adminPage = new ParaBankAdminPage(_webDriver);
            _registerPage = new ParaBankRegisterPage(_webDriver);
            _browser = new BrowserHelper(_webDriver);

            //Registers a user
            _adminPage.NavigateTo();
            _adminPage.ClickCleanButton();
            _adminPage.ClickRegisterButton();
            _registerPage.RegisterUser(UniversalConstants.FirstName, UniversalConstants.LastName, UniversalConstants.UserName, UniversalConstants.Password);
            _registerPage.Logout();

            //Navigates to ParaBanks Home Page for each test
            _paraBankHomePage.NavigateTo();
        }

        #endregion

        #region Tests

        #region Login Tests

        [TestMethod]
        [Description("Login with a valid user")]
        public void ParaBankHomePage_Login_ValidUserAndPassword()
        {
            try
            {
                //Login a user
                _paraBankHomePage.UserLogin(UniversalConstants.UserName, UniversalConstants.Password);

                //Welcome message
                var welcomeMessage = _paraBankHomePage.WelcomeMessage;

                //Validate login is successful by verifying the user receives the Welcome message.
                Assert.IsNotNull(welcomeMessage);
            }
            catch (System.Exception)
            {
                _browser.TakeScreenshot();
                throw;
            }
        }

        [TestMethod]
        [Description("Login with an invalid user")]
        public void ParaBankHomePage_Login_InvalidUser()
        {
            try
            {
                //Login a user
                _paraBankHomePage.UserLogin("baduser", "b@dword");

                //Welcome message
                var actualMessage = _paraBankHomePage.ErrorMessage.Text;
                var expectedMessage = "The username and password could not be verified.";

                //Validate login is successful by verifying the user receives the Welcome message.
                Assert.AreEqual(expectedMessage, actualMessage);
            }
            catch (System.Exception)
            {
                _browser.TakeScreenshot();
                throw;
            }
        }

        [TestMethod]
        [Description("Login with an invalid password")]
        public void ParaBankHomePage_Login_InvalidPassword()
        {
            try
            {
                //Login a user
                _paraBankHomePage.UserLogin("fakeuser", "b@dpass");

                var actualMessage = _paraBankHomePage.ErrorMessage.Text;
                var expectedMessage = "The username and password could not be verified.";

                //Validate login is successful by verifying the user receives the Welcome message.
                Assert.AreEqual(expectedMessage, actualMessage);
            }
            catch (System.Exception)
            {
                _browser.TakeScreenshot();
                throw;
            }
        }

        #endregion

        #endregion
    }
}

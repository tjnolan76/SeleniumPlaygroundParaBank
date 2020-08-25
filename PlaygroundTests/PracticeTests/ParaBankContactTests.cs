using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.PageObjects.PracticePages;
using Playground.SharedResources.Helpers;
using PlaygroundTests.SharedResources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundTests.PracticeTests
{
    [TestClass]
    public class ParaBankContactTests : TestBase
    {
        #region Fields

        private ParaBankContactPage _paraBankContactPage;
        private BrowserHelper _browser;

        #endregion

        #region Initalization

        [TestInitialize]
        public void TestInitialize()
        {
            _paraBankContactPage = new ParaBankContactPage(_webDriver);
            _browser = new BrowserHelper(_webDriver);

            //Navigates to ParaBanks Contact Page for each test
            _paraBankContactPage.NavigateTo();
        }

        #endregion

        #region Tests

        [TestMethod]
        [Description("Contact Customer Care")]
        public void ParaBankContactPage_ContactCustomerCare_Successfully()
        {

            try
            {
                //Arrange
                _paraBankContactPage.Name.SendKeys(UniversalConstants.FirstName);
                _paraBankContactPage.Email.SendKeys(UniversalConstants.Email);
                _paraBankContactPage.Phone.SendKeys(UniversalConstants.Phone);
                _paraBankContactPage.Message.SendKeys("This is a test message");

                //Act
                _paraBankContactPage.SendButton.Click();

                //Assert
                var expectedMessage = "A Customer Care Representative will be contacting you.";
                var actualmessage = _paraBankContactPage.ContactSubmissionResponse.Text;
                Assert.AreEqual(expectedMessage, actualmessage);
            }
            catch (System.Exception)
            {
                _browser.TakeScreenshot();
                throw;
            }
        }

        #endregion
    }
}

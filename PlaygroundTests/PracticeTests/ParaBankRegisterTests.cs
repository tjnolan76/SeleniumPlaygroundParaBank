using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.PageObjects.PracticePages;
using Playground.SharedResources.Constants;
using Playground.SharedResources.Helpers;
using PlaygroundTests.SharedResources;

namespace PlaygroundTests.PracticeTests
{
    [TestClass]
    public class ParaBankRegisterTests : TestBase
    {

        #region Fields

        private static ParaBankAdminPage _adminPage;
        private static ParaBankRegisterPage _registerPage;

        #endregion

        #region Initalization

        [TestInitialize]
        public void TestInitialize()
        {
            _adminPage = new ParaBankAdminPage(_webDriver);
            _registerPage = new ParaBankRegisterPage(_webDriver);
        }

        #endregion

        #region Tests

        [TestMethod]
        [Description("Register User")]
        public void ParaBankRegisterPage_Registration_Successful()
        {
            _adminPage.NavigateTo();

            _adminPage.ClickCleanButton();

            _adminPage.ClickRegisterButton();

            _registerPage.RegisterUser(UniversalConstants.FirstName, UniversalConstants.LastName, UniversalConstants.UserName, UniversalConstants.Password);

            string expectedMessage = "Your account was created successfully. You are now logged in.";
            
            Assert.IsTrue(_registerPage.WelcomeMessage().Contains(expectedMessage));
        }

        #endregion
               
    }
}

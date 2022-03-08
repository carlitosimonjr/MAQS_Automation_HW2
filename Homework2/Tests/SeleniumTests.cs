using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.Utilities.Helper;
using CognizantSoftvision.Maqs.Utilities.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterValidCredentialsTest()
        {
            string username = Config.GetGeneralValue("Username");
            string password = Config.GetGeneralValue("Password");

            LoginPageModel page = new LoginPageModel(this.TestObject);

            // Custom logging
            this.Log.LogMessage(MessageType.INFORMATION, "INFORMATION - Open login page");
            page.OpenLoginPage();

            // Start - Login timer
            this.PerfTimerCollection.StartTimer("Login timer");
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);

            // Custom logging
            this.Log.LogMessage(MessageType.INFORMATION, "INFORMATION - Successful login");

            // Stop - Login timer
            this.PerfTimerCollection.StopTimer("Login timer");

            Assert.IsTrue(homepage.IsPageLoaded());
        }
    }
}

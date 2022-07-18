using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test.TFLJourneyPlannerAutomation.SetUp
{
    public class Context
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver;
        string baseUrl = EnvironmentData.baseUrl;

        public Context(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }
        public void LoadApplicationUnderTest()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _driver.Navigate().GoToUrl(baseUrl);
            _driver.Manage().Window.Maximize();
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("C:/Users/ibito/AppData/Local/Google/Chrome/UserData");
        }      
        public void ShutDownApplicationUnderTest()
        {
            _driver?.Quit();
        }
        public void TakeScreenshotAtThePointOfTestFailure(string directory, string scenarioName)
        {
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            string path = directory + scenarioName + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
            string Screenshot = screenshot.AsBase64EncodedString;
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }
    }
}

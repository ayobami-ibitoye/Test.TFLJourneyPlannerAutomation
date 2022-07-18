using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test.TFLJourneyPlannerAutomation.SetUp
{
    public static class WebDriverExtension
    {

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        internal static void ClearAndSendKeys(this IWebDriver driver, By identifier, string text, int? waitingTime = null)
        {
            driver.FindElement(identifier, 5).Clear();
            driver.FindElement(identifier).SendKeys(text);
            if (waitingTime != null)
            {
                Thread.Sleep(Convert.ToInt16(waitingTime));
            }
            driver.FindElement(identifier).SendKeys(Keys.Tab);
        }
        internal static void Click(this IWebDriver driver, By identifier)
        {
            driver.FindElement(identifier, 5).Click();
        }
        internal static bool SelectOptionByText(this IWebDriver driver, By identifier, string text)
        {
            bool elementToSelectExist = false;
            try
            {
                SelectElement select = new SelectElement(driver.FindElement(identifier, 5));
                Thread.Sleep(1000);
                select.SelectByText(text);
                elementToSelectExist = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return elementToSelectExist;
        }
        internal static string GetElementText(this IWebDriver driver, By identifier)
        {
            return driver.FindElement(identifier, 5).Text.Trim();
        }
    }
}

using OpenQA.Selenium;
using Test.TFLJourneyPlannerAutomation.SetUp;

namespace Test.TFLJourneyPlannerAutomation.Pages
{
    public class JourneyPlannerPage
    {
        private IWebDriver _driver;

        public JourneyPlannerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By planajourneylink = By.CssSelector("ul.collapsible-menu li:nth-child(1)");
        private By fromfield = By.Id("InputFrom");
        private By tofield = By.Id("InputTo");
        private By planmyjourneyBtn = By.CssSelector("#plan-journey-button");
        private By resultName = By.CssSelector("div.headline-container span:nth-child(1)");
        private By resultDetails1 = By.XPath("//*[@id='plan-a-journey']/div[1]/div[1]/div[1]/span[2]/strong");
        private By resultDetails2 = By.XPath("//*[@id='plan-a-journey']/div[1]/div[1]/div[2]/span[2]/strong");
        private By errorMessage = By.CssSelector("ul.field-validation-errors li:nth-child(1)");
        private By acceptcookiesBtn = By.CssSelector("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        private By doneBtn = By.XPath("/html/body/div[1]/div[4]/div[2]/button");
        private By fromFieldErrorMsg = By.Id("InputFrom-error");
        private By toFieldErrorMsg = By.Id("InputTo-error");
        private By changeTime = By.CssSelector("div.time-defaults a:nth-of-type(1)");
        private By dateChange = By.Id("Date");
        private By timeChange = By.Id("Time");
        private By arrivingBtn = By.CssSelector("ul.horizontal-toggle-buttons li:nth-child(2)");
        private By arrivingResult = By.XPath("//*[@id='plan-a-journey']/div[1]/div[2]/strong");
        private By editJourney = By.CssSelector("a.edit-journey span:nth-child(1)");
        private By clearFromFieldBtn = By.CssSelector("#search-filter-form-0>div>div>a");
        private By recentsLink = By.CssSelector("#jp-recent-tab-home>a");
        private By recentJourneys = By.CssSelector("#jp-recent-content-home->a:nth-child(1)");
        private By homePage = By.XPath("//*[@id='full-width-content']/div/div[1]/div/ol/li[1]/a/span");


        public void ClickOnJourneyLink()
        {
            _driver.Click(planajourneylink);
        }
        public void ClickOnCookiesPage()
        {
            _driver.Click(acceptcookiesBtn);
        }
        public void ClickOnDonePage()
        {
            _driver.Click(doneBtn);
        }       
        public void FillFromField(string fromData = null)
        {
            if (!string.IsNullOrEmpty(fromData))
            {
                _driver.ClearAndSendKeys(fromfield, fromData);
            }            
        }
        public void FillToField(string toData = null)
        {
            if (!string.IsNullOrEmpty(toData))
            {
                _driver.ClearAndSendKeys(tofield, toData);
            }            
        }
        public void ClickOnJourneyButton()
        {
            _driver.Click(planmyjourneyBtn);
        }
        public string VerifyResultPage()
        {
            return _driver.GetElementText(resultName);
        }
        public string VerifyFirstResultDetails()
        {
            return _driver.GetElementText(resultDetails1);
        }
        public string VerifySecondResultDetails()
        {
            return _driver.GetElementText(resultDetails2);
        }
        public string VerifyErrorMessage()
        {
            return _driver.GetElementText(errorMessage);
        }
        public string GetFromFieldErrorMessage()
        {
            return _driver.GetElementText(fromFieldErrorMsg);
        }
        public string GetToFieldErrorMessage()
        {
            return _driver.GetElementText(toFieldErrorMsg);
        }
        public void ClickOnChangeTime()
        {
            _driver.Click(changeTime);
        }
        public void ClickOnArrivingButton()
        {
            _driver.Click(arrivingBtn);
        }
        public void ClickOnDateChange(string date)
        {
            _driver.SelectOptionByText(dateChange, date);
        }
        public void ClickOnTimeChange(string time)
        {
            _driver.SelectOptionByText(timeChange, time);
        }
        public string VerifyArrivingResult()
        {
            return _driver.GetElementText(arrivingResult);
        }
        public void ClickOnEditJourneyLink()
        {
            _driver.Click(editJourney);
            
        }
        public void ClickOnUpdateJourneyButton()
        {
            _driver.Click(planmyjourneyBtn);
        }
        public void ClearFromField()
        {
            _driver.Click(clearFromFieldBtn);
        }
        public void ClickOnRecentsLink()
        {
            _driver.Click(recentsLink);
        }
        public string VerifyRecentJourneys()
        {
            return _driver.GetElementText(recentJourneys);
        } 
        
        public void ClickOnHomePage()
        {
            _driver.Click(homePage);
        }
    }
}

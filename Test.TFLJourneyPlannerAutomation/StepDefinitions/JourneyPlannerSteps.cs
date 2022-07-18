using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Test.TFLJourneyPlannerAutomation.Pages;
using Test.TFLJourneyPlannerAutomation.SetUp;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace Test.TFLJourneyPlannerAutomation.StepDefinitions
{
    [Binding]
    public class JourneyPlannerSteps
    {
        private Context _context;
        private JourneyPlannerPage _journeyPlannerPage;
        static ExtentTest feature;
        static ExtentTest scenario;
        static ExtentReports report;
        ScenarioContext _scenarioContext;

        public JourneyPlannerSteps(Context context, JourneyPlannerPage journeyPlannerPage, ScenarioContext scenarioContext)
        {
            _context = context;
            _journeyPlannerPage = journeyPlannerPage;
            _scenarioContext = scenarioContext;
        }

        [Given(@"that the TFL application is loaded")]
        public void GivenThatTheTFLApplicationIsLoaded()
        {
            _context.LoadApplicationUnderTest();
            _journeyPlannerPage.ClickOnCookiesPage();
            _journeyPlannerPage.ClickOnDonePage();
            scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [When(@"I click on Plan a journey link")]
        public void WhenAUserClicksOnPlanAJourneyLink()
        {
            _journeyPlannerPage.ClickOnJourneyLink();
        }

        [When(@"I fill-in From field with (.*)")]
        public void WhenAUserFillsInFromFieldWithDAUG(string fromData)
        {

            _journeyPlannerPage.FillFromField(fromData);
        }

        [When(@"I fill-in To field with (.*)")]
        public void WhenAUserFillsInToFieldWithERD(string toData)
        {
            _journeyPlannerPage.FillToField(toData);
        }

        [When(@"I click on Plan a journey button")]
        public void WhenAUserClicksOnPlanAJourneyButton()
        {
            _journeyPlannerPage.ClickOnJourneyButton();
        }

        [Then(@"the result page (.*) Must be displayed")]
        public void ThenTheResultPageJourneyResultsMustBeDisplayed(string expectedResult)
        {
            Assert.IsTrue(expectedResult.Equals(_journeyPlannerPage.VerifyResultPage()));
        }

        [Then(@"the search data (.*) and (.*) are displayed")]
        public void ThenTheSearchDataAreDisplayed(string expectedResult1, string expectedResult2)
        {
            Assert.IsTrue(expectedResult1.Equals(_journeyPlannerPage.VerifyFirstResultDetails()));
            Assert.IsTrue(expectedResult2.Equals(_journeyPlannerPage.VerifySecondResultDetails()));
        }

        [Then(@"the result (.*) must be displayed")]
        public void ThenTheResultMustBeDisplayed(string expectedResult)
        {
            Assert.IsTrue(expectedResult.Equals(_journeyPlannerPage.VerifyErrorMessage()));
        }

        [When(@"I fill in From field with blank data")]
        public void WhenAUserFillsInFromFieldWithBlankData()
        {
            _journeyPlannerPage.FillFromField();

        }

        [When(@"I fill in To field with blank data")]
        public void WhenAUserFillsInToFieldWithBlankData()
        {
            _journeyPlannerPage.FillToField();
        }

        [Then(@"an error message (.*) should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string expectedErrorMessage)
        {
            string actualErrormessage = string.Empty;

            if (expectedErrorMessage.Equals("The From field is required."))
            {
                actualErrormessage = _journeyPlannerPage.GetFromFieldErrorMessage();
            }
            else if (expectedErrorMessage.Equals("The To field is required."))
            {
                actualErrormessage = _journeyPlannerPage.GetToFieldErrorMessage();
            }

            Assert.IsTrue(actualErrormessage.Equals(expectedErrorMessage));
        }

        [When(@"I click on change time link")]
        public void WhenAUserClicksOnChangeTimeLink()
        {
            _journeyPlannerPage.ClickOnChangeTime();
        }

        [When(@"I click on Arriving")]
        public void WhenAUserClicksOnArriving()
        {
            _journeyPlannerPage.ClickOnArrivingButton();
        }

        [When(@"I select (.*) from the dropdown")]
        public void WhenAUserSelectsThuJulFromTheDropdown(string date)
        {
            _journeyPlannerPage.ClickOnDateChange(date);
        }

        [When(@"I choose (.*) from the list")]
        public void WhenAUserChoosesFromTheList(string time)
        {
            _journeyPlannerPage.ClickOnTimeChange(time);
        }

        [Then(@"the search data (.*) must be displayed")]
        public void ThenTheSearchDataThursdayThJulMustBeDisplayed(string expectedMessage)
        {
            Assert.IsTrue(expectedMessage.Equals(_journeyPlannerPage.VerifyArrivingResult()));
        }

        [When(@"I click on Edit journey link")]
        public void WhenAUserClicksOnEditJourneyLink()
        {
            _journeyPlannerPage.ClickOnEditJourneyLink();
            _journeyPlannerPage.ClearFromField();
        }

        [When(@"I click on Update journey button")]
        public void WhenAUserClicksOnUpdateJourneyButton()
        {
            _journeyPlannerPage.ClickOnUpdateJourneyButton();
        }

        [When(@"I click on Recents link")]
        public void WhenAUserClicksOnRecentsLink()
        {
            _journeyPlannerPage.ClickOnRecentsLink();
        }

        [Then(@"the recent search (.*) must be displayed")]
        public void ThenTheRecentSearchDADYToERDMustBeDisplayed(string expectedMessage1)
        {
            Assert.IsTrue(expectedMessage1.Equals(_journeyPlannerPage.VerifyRecentJourneys()));
        }

        [When(@"I fill-in a new journey page with (.*), (.*) fields")]
        public void WhenAUserFills_InANewJourneyPageWithDADYERDFields(string fromData, string toData)
        {
            _journeyPlannerPage.FillFromField(fromData);
            _journeyPlannerPage.FillToField(toData);
        }

        [When(@"I click on HomePage link")]
        public void WhenIClickOnHomePageLink()
        {
            _journeyPlannerPage.ClickOnHomePage();
        }


        [BeforeTestRun]
        public static void ReportGenerator()
        {
            var testResultReport = new ExtentHtmlReporter(AppDomain.CurrentDomain.BaseDirectory);
            testResultReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            report = new ExtentReports();
            report.AttachReporter(testResultReport);
        }

        [AfterTestRun]
        public static void ReportCleaner()
        {
            report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void StepsInTheReport()
        {
            var typeOfStep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //Cater for a step that passed
            if (_scenarioContext.TestError == null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            //Cater for a step that failed
            if (_scenarioContext.TestError != null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
            }
            //Cater for a step that has not been implemented
            if (_scenarioContext.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
            }
        }

        [AfterScenario]
        public void CloseApplicationUnderTest()
        {
            try
            {
                if (_scenarioContext.TestError != null)  //this condition will always be true when a test failed
                {
                    string scenarioName = _scenarioContext.ScenarioInfo.Title;
                    string directory = AppDomain.CurrentDomain.BaseDirectory + @"\Screenshots\";
                    _context.TakeScreenshotAtThePointOfTestFailure(directory, scenarioName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _context.ShutDownApplicationUnderTest();
            }
        }
    }
}

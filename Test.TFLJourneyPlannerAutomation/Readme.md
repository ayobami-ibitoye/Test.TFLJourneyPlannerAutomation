Project Name: Test.TFLJourneyPlannerAutomation

Pre-Requisites for Project Execution
	Visual Studio 2019
	Latest Chrome Driver Version 103.0.5060.114

Automation Framework Design Approach

IDE & Language
	Visual Studio 2019 & C#

Automation Tool
	Selenium WebDriver

Project Type
	BDD-SpecFlow

DataDriven
	Scenario 
	Scenario Outline

Reports
	Extent Reports

Browsers
	Chrome Driver

Test Scenarios
	Scenario 1: A user can plan a journey successfully 
	Scenario 2: A user cannot plan a journey with invalid location data
	Scenario 3: A user cannot plan a journey with no location data
	Scenario 4: A user can plan a journey successfully based on arrival time
	Scenario 5: A user can modify a successfully planned journey
	Scenario 6: Recents tab display recently planned journeys

 Brief Description of Framework Approach
	Reports are created using ExtentReports and ScreenShots is used to capture failed Scenarios.
	In Project Solution
		Runsettings file included to show that test can be run in different environments.
		Locators are defined in JourneyPlannerPage
		NuGet packages needs to be restored before test run
		Contains a Local Run Settings which must be selected before any test run. This can be done by navigating to Test and then Configure Run Settings.

BDDFramework (SpecFlow Project)
	Feature Files
	StepDefinitions Files
	Pages Files
	SetUp Files
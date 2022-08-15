Feature: JourneyPlanner
	
Scenario Outline: 01_Verify a user can plan a journey succesfully 
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in a new journey page with <From>, <To> fields
	And I click on Plan a journey button
	Then the result page Journey results Must be displayed 
	And the search data <ExpectedResult1> and <ExpectedResult2> are displayed
	Examples: 
	| From                      | To                        | ExpectedResult1           | ExpectedResult2           |
	| DA1 1DY                   | E16 2RD                   | DA1 1DY                   | E16 2RD                   |
	| Dartford Rail Station     | Cyprus DLR Station        | Dartford Rail Station     | Cyprus DLR Station        |
	| 16 Richmond Lane Dartford | 26 Old Bond Street London | 16 Richmond Lane Dartford | 26 Old Bond Street London |


@Regression
Scenario: 02_Verify that a user cannot plan a journey with invalid location data
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in From field with E16 2RD
	And I fill-in To field with ER3 6YF
	And I click on Plan a journey button
	Then the result page Journey results Must be displayed 
	And the result Sorry, we can't find a journey matching your criteria must be displayed


Scenario: 03_Verify that a user cannot plan a journey with no location data
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill in From field with blank data
	And I fill in To field with blank data
	And I click on Plan a journey button
	Then an error message <ExpectedErrorMessage> should be displayed
	Examples:
	| FromField | ToField | ExpectedErrorMessage        |
	|           |         | The From field is required. |
	|           |         | The To field is required.   |
	
Scenario: 03_01_Verify that a user cannot plan a journey with no input From data
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill in From field with blank data
	And I fill-in To field with E16 2RD
	And I click on Plan a journey button
	Then an error message <ExpectedErrorMessage> should be displayed
	Examples:
	| FromField | ToField | ExpectedErrorMessage        |
	|           | E16 2RD | The From field is required. |

Scenario: 03_02_Verify that a user cannot plan a journey with no input To data
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in From field with E16 2RD
	And I fill in To field with blank data
	And I click on Plan a journey button
	Then an error message <ExpectedErrorMessage> should be displayed
	Examples:
	| FromField | ToField | ExpectedErrorMessage        |
	| E16 2RD   |         | The To field is required.   |

Scenario: 04_Verify that a user can plan a journey based on arrival time
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in From field with DA1 1DY
	And I fill-in To field with E16 2RD
	And I click on change time link
	And I click on Arriving
	And I select Fri 26 Aug from the dropdown
	And I choose 10:00 from the list
	And I click on Plan a journey button
	Then the result page Journey results Must be displayed
	And the search data DA1 1DY and E16 2RD are displayed
	And the search data Friday 26th Aug, 10:00 must be displayed

Scenario: 05_Verify that a user can modify a succesfully planned journey
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in From field with DA1 5TW
	And I fill-in To field with E16 2RD
	And I click on Plan a journey button
	And I click on Edit journey link 
	And I fill-in From field with DA1 1DY
	And I click on Update journey button
	Then the result page Journey results Must be displayed
	And the search data DA1 1DY and E16 2RD are displayed

Scenario: 06_Verify that the recents tab display recently planned journeys
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in From field with DA1 5TW
	And I fill-in To field with E16 2RD
	And I click on Plan a journey button
	And I click on HomePage link
	And I click on Recents link
	Then the recent search DA1 5TW to E16 2RD must be displayed

Scenario: 01_AnOptionToScenario1_Verify that a user can plan a journey succesfully
	Given that the TFL application is loaded
	When I click on Plan a journey link
	And I fill-in From field with DA1 1DY
	And I fill-in To field with E16 2RD
	And I click on Plan a journey button
	Then the result page Journey results Must be displayed 
	And the search data DA1 1DY and E16 2RD are displayed
	
Feature: LandingPage

@LogIn
Scenario: Log on to the aplication
	Given the log on details is entered
	When the submit button is clicked
	Then the user is logged in successfully


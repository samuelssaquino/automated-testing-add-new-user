Feature: AccessApplication
	As a user
	I want to access the application
	And check the page title

@accessApplication
Scenario: Access the application
	Given I access the page "https://samuelssaquino.github.io/crud-javascript/"
	Then the page title should be "Register"
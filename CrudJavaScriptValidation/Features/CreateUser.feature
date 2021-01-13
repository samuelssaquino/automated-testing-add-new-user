Feature: AddUser
	As a system user
	I want to add a new user
	And verify that all fields have been successfully registered

@createUser
Scenario: Add User
	Given I access the page "https://samuelssaquino.github.io/crud-javascript/"
	And I check the "USER REGISTRATION" page
	Then I click on the add user button
	And I verify that the modal register is displayed
	Then I enter the field first name with "Samuel"
	Then I enter the field last name with "Aquino"	
	And I enter the other fields with valid data
	When I click the save button
	Then The application should display the message "The user Samuel Aquino has been successfully registered!"
	And The application should display the registered user in the list
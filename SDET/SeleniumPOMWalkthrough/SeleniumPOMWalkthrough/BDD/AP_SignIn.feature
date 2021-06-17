Feature: AP_SignIn
	In order to be able to buy items
	As a registered user on the automation practice website
	I want to be able to sign into my account

@Login
Scenario: Invalid password - too short
	Given I am on the sign in page
	And I enter the email "testing@snailmail.ccm"
	And I enter the password <password>
	When I click the sign in button
	Then I should see an alert containing the error message "Invalid password"
	Examples: 
	| password |
	| 1234     |
	| hihi     |
	| nish     |

@Login
Scenario: Invalid email - email not registered
	Given I am on the sign in page
	And I enter the email "testingsnailmail.ccm"
	And I enter the password four
	When I click the sign in button
	Then I should see an alert containing the error message "Invalid email address"

@google
@Login
Scenario: Invalid email - using SpecFlow assist
	Given I am on the sign in page
	And I have the credentials:
	| Email    | Password |
	| test.com | nish     |
	When I enter these credentails
	And I click the sign in button
	Then I should see an alert containing the error message "Invalid email address"


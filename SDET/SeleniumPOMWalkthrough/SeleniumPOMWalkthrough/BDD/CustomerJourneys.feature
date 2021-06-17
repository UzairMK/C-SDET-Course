Feature: CustomerJourneys
	In order to contact staff for help
	As a registered user on the automation practice website
	I want to be able to submit a message to staff on the website

@Happy
@ContactUs
Scenario: Submit a successful message
	Given I want to submit a message to staff so I navigate to the contact us page
	When I fill in the required fields:
	| SubjectOption | Email                 | OrderReference | Message |
	| 1             | testing@snailmail.com |                | message |
	And I press send
	Then I should receive the message "Your message has been successfully sent to our team"

@Sad
@ContactUs
Scenario: Submit a message multiple times, after each attempt follow the alert message until success
	Given I want to submit a message to staff so I navigate to the contact us page
	When I don't fill in any fields 
	And I press send. I should receive the message "Invalid email address"
	And then I fill in the email field
	And I press send. I should receive the message "The message cannot be blank"
	And then I fill in the message field
	And I press send. I should receive the message "Please select a subject from the list provided"
	And then I select a subject heading
	And I press send
	Then I should receive the message "Your message has been successfully sent to our team"
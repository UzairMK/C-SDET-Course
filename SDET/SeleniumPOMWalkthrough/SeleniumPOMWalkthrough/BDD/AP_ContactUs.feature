Feature: AP_ContactUs
	
@Sad
@Contact Us
Scenario: No fields filled
	Given I am on the contact us page
	When I click the send button
	Then I should see an send alert containing the error message "Invalid email address"

@Sad
@Contact Us
Scenario: Only email filled
	Given I am on the contact us page
	And I enter "testing@snailmail.ccm" in the contact us email field
	When I click the send button
	Then I should see an send alert containing the error message "The message cannot be blank"

@Sad
@Contact Us
Scenario: Only email and message filled
	Given I am on the contact us page
	And I enter "testing@snailmail.ccm" in the contact us email field
	And I enter "message" in the contact us message field
	When I click the send button
	Then I should see an send alert containing the error message "Please select a subject from the list provided"

@Happy
@Contact Us
Scenario: All required fields filled
	Given I am on the contact us page
	And I know the values I going to put in the contact us fields:
	| SubjectOption | Email                 | OrderReference | Message |
	| 1             | testing@snailmail.com |                | message |
	When I input those values in the contact us fields
	And I click the send button
	Then I should see an send alert containing the error message "Your message has been successfully sent to our team"

@Happy
@Contact Us
Scenario: Customer service message under subject combo box
	Given I am on the contact us page
	And I know the values I going to put in the contact us fields:
	| SubjectOption | Email | OrderReference | Message |
	#| 0             |       |                |         |
	| 1             |       |                |         |
	#| 2             |       |                |         |
	When I input those values in the contact us fields
	Then I should see "For any question about a product, an order" message under the subject combo box
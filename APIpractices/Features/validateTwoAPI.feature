Feature: validateTwoAPI

A short summary of the feature

@tag1
Scenario: Validating information from one API to another API source
	Given I open the user page of a specific user and copied their information from the reqres API
	When I open the list of users page in the reqres API
	Then I should be able to find my specific user on the list 

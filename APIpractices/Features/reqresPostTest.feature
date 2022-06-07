Feature: reqresPostTest

A short summary of the feature

@tag1
Scenario: Post a new user detail in the reqres api
	Given I want to connect to the reqres user create API
	When I am connected the correct status code is shown
	Then I input the name of the user and their role 
	#And I want to edit the details of that specific user

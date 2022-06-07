Feature: postTable

A short summary of the feature

@tag1
Scenario Outline: Opening the reqres API list of pages 
	Given I enter <name> and <job> on reqres api
	When the information is sent should give me the correct status code
	Then I will check if the correct <name> and <job> was sent over
	Examples: 
	| name | job       |
	| Mike | QA        |
	| Joe  | Developer |

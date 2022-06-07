Feature: putTable

A short summary of the feature

@tag1
Scenario Outline: Editing details on users on the reqres API
	Given I have set of <id> I want to change their <name> and <job>
	When the edit has been sent I should get a correct status code
	Then I should check if the edited <name> and <job> has been updated
	Examples: 
	| id | name  | job       |
	| 2  | Mary  | President |
	| 3  | Steve | COO       |
	| 4  | Harry | Manager   |


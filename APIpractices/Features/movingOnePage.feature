Feature: movingOnePage

A short summary of the feature

@tag1
Scenario Outline: I want to move a page on the reqres user api
	Given I open a reqres user api <page>
	Then I should get a correct status code
	Examples: 
	| page |
	| 1    |
	| 2    |
	| 3    |
	| 4    |
	| 5    |
	| 6    |

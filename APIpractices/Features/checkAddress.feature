Feature: checkAddress

A short summary of the feature

@tag1
Scenario: going to the zippotam api and searching for a specific locationn
	Given I connect to the zippostam api
	When I am connected I should get a correct status code
	Then I should get a correct information on my request
	

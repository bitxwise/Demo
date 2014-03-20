Feature: Help users write search queries
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add content assist to the Google Search field
	Given user is about to search
	When user begins typing query
	Then a list of suggestions should appear below the search field
	And the suggestions should update as user types

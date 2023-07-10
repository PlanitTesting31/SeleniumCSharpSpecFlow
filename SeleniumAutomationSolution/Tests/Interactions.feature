Feature: Interactions
	Verification of interactions

Background: 
	Given I navigate to "Interactions" sections of the homepage

Scenario: Verification of sort list
	When I click list in Sortable
	Then list is sorted in descending order

Scenario: Verification of drag and drop message
	When I do simple drag and drop in Droppable
	Then dropped message is populated





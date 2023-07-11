Feature: Interactions
	Verification of interactions

Background:
	Given I navigate to "Interactions" sections of the homepage

Scenario: Verification of sort list
	When I sort the list content
	Then list is sorted in descending order

Scenario: Verification of drag and drop message
	When I drag the text box and drop on 'Drop here' text box
	Then dropped message is populated
Feature: AlertsAndWindows
	Validate alerts and windows

Background: 
	Given I navigate to "Alerts, Frame & Windows" sections of the homepage

Scenario: Verification of the Browser Windows
	When I click buttons in "Browser Windows" from the table:
	|Button|
	|New Window|
	Then sample heading text is populated

#Failed to get text from new window
Scenario: Verification of the Browser Window Message
	When I click button in "Browser Windows" from the table:
	|Button|
	|New Window Message|
	Then sample heading message is populated

Scenario: Verification on button click prompt box will appear
	When I click prompt button in "Alerts" and enter text from the table:
	|Name|
	| Prompt Button |
	Then alert message is populated



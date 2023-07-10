Feature: AlertsAndWindows
	Validate alerts and windows

Background:
	Given I navigate to "Alerts, Frame & Windows" sections of the homepage

Scenario: Verification of the Browser Windows
	When I click following buttons in Browser Windows page
		| ButtonName |
		| New Window |
	Then sample heading text is populated in new tab

Scenario: Verification of the Browser Window Message
	When I click following buttons in Browser Windows page
		| ButtonName         |
		| New Window Message |
	Then sample heading message is populated in new window

Scenario: Verification on button click prompt box will appear
	When I click following buttons in Alerts page
		| ButtonName    |
		| Prompt Button |
	Then alert message is populated
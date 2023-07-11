Feature: Widgets
	Widgets Verification

Background:
	Given I navigate to "Widgets" sections of the homepage

Scenario: Verification widgets for multiple colors
	When I click Auto Complete to enter data from the table:
		| ColorName |
		| Blue      |
		| Black     |
	Then the data is submitted correctly from the table:
		| ColorName |
		| Blue      |
		| Black     |

Scenario: Verification widgets for single color
	When I click Auto Complete to enter the data from the table:
		| ColorName |
		| Blue      |
	Then the details are submitted correctly from the table:
		| ColorName |
		| Blue      |

Scenario: Verification of select date
	When I click Date Picker to select today date
	Then the date is selected correctly

Scenario: Verification of select date and time
	When I click Date Picker to select today date and time
	Then the date and time is selected correctly

Scenario:Verification of tool tip info content
	When I click Tool Tips and mouser over the content
		| ToolTipContent |
		| Contrary       |
	Then the info validated correctly for tool tip from the table:
		| ToolTipContent |
		| Contrary       |
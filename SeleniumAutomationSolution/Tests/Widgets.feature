Feature: Widgets
	Widgets Verification
Background: 
	Given I navigate to "Widgets" sections of the homepage

Scenario: Verification widgets for multiple colors
	When I click "Auto Complete" to enter data from the table:
	| ColorName1 | ColorName2 |
	| Blue        | Black     |		
	Then the data is submitted correctly from the table:
	| ColorName1 | ColorName2 |
	| Blue        | Black     |	

Scenario: Verification widgets for single color
	When I click "Auto Complete" to enter the data from the table:
	| ColorName|
	| Blue        |	
	Then the details are submitted correctly from the table:
	| ColorName | 
	| Blue        |

Scenario: Verification of select date
	When I click "Date Picker" to select date from the table:
	| Month  | Year | Date |
	| August | 2024 | 19   |
	Then the date is selected correctly with data from the table:
	| Month  | Year | Date |
	| August | 2024 | 19|

Scenario: Verification of select date and time
	When I click "Date Picker" to select date and time from the table:
	| Month  | Year | Date | Time  |
	| August | 2024 | 19   | 03:30 |
	Then the date and time is selected correctly with data from the table:
	| Month  | Year | Date | Time  |
	| August | 2024 | 19   | 3:30 |

Scenario:Verification of tool tip info content
	When I click "Tool Tips" and mouser over the content
	| ToolTipContent |
	|Contrary|
	Then the info validated correctly for tool tip from the table:
	| ToolTipContent |
	|Contrary|
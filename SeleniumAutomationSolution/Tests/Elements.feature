Feature: Elements
	Validating Elements

Background:
	Given I navigate to "Elements" sections of the homepage

Scenario: Verification the details of text of submitted text box details
	When I submit text box details with data from the table
		| FullName | Email        | CurrentAddress | PermanentAddress |
		| SS       | SS@gmail.com | Hyderabad      | Hyderabadz       |
	Then the details of user should be submitted successfully

Scenario: Verification of the selected check box items
	When I expand the following check box in the page
		| ExpandMenu |
		| Home       |
		| Desktop    |
	And I select the check box
		| Name  |
		| Notes |
	Then the checkbox details should be displayed from the table:
		| Name  |
		| notes |

Scenario: Editing the contents of the web table
	When I search details of the user in Web Tables page
		| FirstName |
		| Cierra    |
	And I update "age" of the user
	Then the age is successfully updated in web table

Scenario: Verification of the button selected
	When I click following button from Buttons page
		| Button   |
		| Click Me |
	Then the message is populated in the page
		| Message                       |
		| You have done a dynamic click |

Scenario: Verification of uploading a file
	When I upload a file in 'upload and download' page
	Then file is uploaded successfully

Scenario: Verification of downloading a file
	When I download a file in 'upload and download' page
	Then file is downloaded successfully
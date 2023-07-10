Feature: Elements 
	Validating Elements
Background: 
	Given I navigate to "Elements" sections of the homepage


	
Scenario: Verification the details of text of submitted text box details	
	When I submit Text Box details with data from the table:
	| FullName   | Email | CurrentAddress | PermanentAddress |
	|SS|SS@gmail.com|Hyderabad|Hyderabadz|
	Then the submitted details of user should be displayed from the table:
	| FullName   | Email | CurrentAddress | PermanentAddress |
	|SS|SS@gmail.com|Hyderabad|Hyderabadz|


Scenario: Verification of the selected check box items	
	When I expand the following Check Box in the page and select the checkbox's from the table:
	| Home    | Desktop |
	| Desktop| Notes  |
	Then the checkbox details should be displayed from the table:
	| Desktop |
	| notes   |


Scenario: Editing the contents of the web table	
	When I search details of the user in Web Tables page
	| FirstName |
	| Cierra    |
	And I update "age" of the user
	Then the age is successfully updated in web table

Scenario: Verification of the button selected
	When I click following button from Buttons page
	| Button |
	|Click Me|
	Then the message is populated in the page
	| Message |
	|Click Me|

Scenario: Verification of upload and download
	When I click Upload and Download for file
	Then upload and download of file is successful







     


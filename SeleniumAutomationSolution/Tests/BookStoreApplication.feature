Feature: BookStoreApplication
	Simple calculator for adding two numbers
Background: 
	Given I navigate to "Book Store Application" sections of the homepage

Scenario: Verification of success login
	When I  "Login" with details from the table:
	| UserName | Password |
	|   BookStore       |     Testing@123     |
	Then user login is successful with details from the table:
	| UserName |
	|BookStore|
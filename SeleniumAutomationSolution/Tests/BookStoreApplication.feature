Feature: BookStoreApplication
	Simple calculator for adding two numbers

Background:
	Given I navigate to "Book Store Application" sections of the homepage

Scenario: Verification of success login
	When I login into the book store application
	Then user login is successfull
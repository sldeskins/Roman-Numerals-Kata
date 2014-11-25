Feature: Implement Arabic to Roman
As a games designer 
 I want to pass in an arabic number and get a Roman numeral back 
 So that I can correctly label my game releases using Roman numerals 

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
    When an arabic number is passed, the correct Roman numeral is returned. 
	Then all Roman numerals between 1 and 3000 are returned correctly.

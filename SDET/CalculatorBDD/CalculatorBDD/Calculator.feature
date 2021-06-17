Feature: Calculator
	Simple calculator for adding two numbers

@add
Scenario: Add
	Given I have a calculator
	And I enter 5 and 2 into the calculator
	When I press add
	Then the result should be 7

@subtract
Scenario: Subtract
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press subtract
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 5      | 2      | 3      |
	| 1000   | 1      | 999    |
	| 10     | 10     | 0      |
	| 0      | 5      | -5     |

@Multiply
Scenario: Multiply
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press multiply
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 1      |
	| 2      | 3      | 6      |

@Divide
Scenario: Divide
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press divide
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 5      | 2      | 2      |
	| 1000   | 10     | 100    |

@Divide
Scenario: Dividing by zero
	Given I have a calculator
	And I enter 1 and 0 into the calculator
	When I press divide
	Then an exception message "Can not divide by zero" should be thrown

@sumofevennumbers
Scenario: SumOfNumbersDivisbleBy2
Given I have a calculator
And I enter the numbers below to a list
| nums |
| 1    |
| 2    |
| 3    |
| 4    |
| 5    |
When I iterate through the list to add all the even numbers
Then the result should be 6

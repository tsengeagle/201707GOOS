Feature: BudgetCreate
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@web
@CleanBudget
Scenario: Success add a budget

Given go to adding budget page
When I add a buget 2000 for "2017-10"
Then it should display "added successfully"

@web
@CleanBudget
Scenario: Add a budget when there was existed budget with same year month
Given budget table has a budget
| Amount | YearMonth |
| 1000   | 2017-01   |
Given go to adding budget page
When I add a buget 2000 for "2017-01"
Then it should display "added successfully"

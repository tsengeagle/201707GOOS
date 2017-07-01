
Feature: BudgetController

@CleanBudget
Scenario: Add a budget record
When add a budget
| Amount | Month   |
| 2000   | 2017-02 |
Then ViewBag should have a message for adding successfully
And it should exist a budget record in budget table
| Amount | YearMonth |
| 2000   | 2017-02   |

@CleanBudget
Scenario: Update a budget record
Given budget table has a budget
| Amount | YearMonth |
| 1000   | 2017-02   |
When add a budget
| Amount | Month   |
| 2000   | 2017-02 |
Then ViewBag should have a message for updating successfully
And it should exist a budget record in budget table
| Amount | YearMonth |
| 2000   | 2017-02   |


﻿Feature: BudgetCreate
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@web
Scenario: Success add a budget

Given go to adding budget page
When I add a buget 2000 for "2017-10"
Then it should display "added successfully"
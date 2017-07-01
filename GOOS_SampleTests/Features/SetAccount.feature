Feature: SetAccount



Scenario: Success set an account
Given go to adding account page
When I add a account with account id = "123456" and account name = "test account"
Then it should display "add account done!"

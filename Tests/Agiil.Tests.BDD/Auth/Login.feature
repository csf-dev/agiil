Feature: Users can log into the application
  Users should be able to log in if they have an account.
  They will only be able to log in if they use a correct username and password combination.

Background:
  Given Agiil has just been installed
    And Joe has a user account with the username 'joebloggs' and password 'secret'
    And Joe is on on the application home page

Scenario: Joe cannot log in if he uses a username which does not match any accounts.
   When Joe attempts to log in with a username 'johndoe' and password 'secret'
   Then he should see a login failure message
    And he should not be logged in

Scenario: Joe cannot log in if he uses the wrong password.
   When Joe attempts to log in with a username 'joebloggs' and password 'incorrect'
   Then he should see a login failure message
    And he should not be logged in

Scenario: Joe can log in successfully if he uses the right username and password.
   When Joe attempts to log in with a username 'joebloggs' and password 'secret'
   Then he should be logged in as 'joebloggs'
﻿Feature: Log in to the application
  Users should be able to log in if they have an account
  They will only be able to log in if they use a correct password

Scenario: The user cannot log in if they use a username which does correspond to any user accounts
  Given there is not a user account named 'johndoe'
   When the user attempts to log in with a username 'johndoe' and password 'secret'
   Then the user is not logged in successfully

Scenario: The user cannot log in if they use an incorrect password for an existing user account
  Given there is a user account named 'johndoe' with the password 'secret'
   When the user attempts to log in with a username 'johndoe' and password 'incorrect'
   Then the user is not logged in successfully

Scenario: The user is logged in successfully if they use a correct username and password for an existing user account
  Given there is a user account named 'johndoe' with the password 'secret'
   When the user attempts to log in with a username 'johndoe' and password 'secret'
   Then the user is logged in successfully  
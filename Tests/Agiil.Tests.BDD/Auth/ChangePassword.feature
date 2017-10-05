﻿Feature: Users can change their own password
  Users should be able to change their own password if they are logged in.
  This will help users self-manage security risks due to compromised or aged passwords.

Background:
  Given Agiil has just been installed
    And Youssef is logged into the site as a normal user

Scenario: Youssef can change his password if he enters appropriate details
   When Youssef correctly changes his password to 'test_password_123'
    And Youssef logs out
    And Youssef attempts to log in with a username 'Youssef' and password 'test_password_123'
   Then Youssef should be logged in as 'Youssef'

Scenario: Youssef should see a success message after he has changed his password correctly
   When Youssef correctly changes his password to 'test_password_123'
   Then Youssef should see a password-change success message

Scenario: Youssef should see a failure message if he tries to change his password and enters an incorrect current password
   When Youssef attempts to change his password to 'test_password_123' using an incorrect current password
   Then Youssef should see a password-change failure message

Scenario: Youssef's password should not be changed if he enters an incorrect current password
   When Youssef attempts to change his password to 'test_password_123' using an incorrect current password
    And Youssef logs out
    And Youssef attempts to log in with a username 'Youssef' and password 'test_password_123'
   Then Youssef should not be logged in

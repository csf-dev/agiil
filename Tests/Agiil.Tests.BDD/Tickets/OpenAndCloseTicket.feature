Feature: Open or close a ticket
  A user should be able to close a tickets which have been resolved, in order to remove them
  from view.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can close a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1'
   When he closes the ticket
   Then he should see that the ticket state is closed

Scenario: Youssef can re-open a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1'
    And he has closed the ticket
   When he reopens the ticket
   Then he should see that the ticket state is open

Feature: Open or close a ticket
  A user should be able to close a tickets which have been resolved, in order to remove them
  from view.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can close a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When Youssef closes the ticket
   Then Youssef should see that the ticket state is closed

Scenario: Youssef can re-open a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
    And Youssef has closed the ticket
   When Youssef reopens the ticket
   Then Youssef should see that the ticket state is open

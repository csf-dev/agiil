Feature: Open or close a ticket
  A user should be able to close a tickets which have been resolved, in order to remove them
  from view.

Background:
  Given Agiil has just been installed
    And April has set up the simple sample project
    And Youssef is logged into the site as a normal user

Scenario: Youssef can close a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When Youssef closes the ticket
   Then Youssef should see that the ticket state is closed

Scenario: Youssef can re-open a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When Youssef reopens the ticket
   Then Youssef should see that the ticket state is open

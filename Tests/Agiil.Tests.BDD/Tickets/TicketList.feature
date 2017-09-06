Feature: Listing the tickets
  Users should be able to see a list of the existing tickets, sorted by creation date.
  By default, closed tickets are filtered out of the results.

Background:
  Given Agiil has just been installed
    And April has set up the simple sample project
    And Youssef is logged into the site as a normal user
  
Scenario: Youssef can see a ticket which exists in the list
   When Youssef looks at the list of tickets
   Then Youssef should be able to find a ticket with the title 'Sample ticket 1'

Scenario: Youssef can't see closed tickets in the list
   When Youssef looks at the list of tickets
   Then Youssef should be not able to find a ticket with the title 'Sample ticket 4'

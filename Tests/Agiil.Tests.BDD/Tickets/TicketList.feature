Feature: Listing the tickets
  Users should be able to see a list of the existing tickets, sorted by creation date.
  By default, closed tickets are filtered out of the results.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
  
Scenario: Youssef can see a ticket which exists in the list
   When Youssef looks at the list of tickets
   Then he should be able to find a ticket with the title 'Sample ticket 1'

Scenario: Youssef can't see closed tickets in the list
   When Youssef looks at the list of tickets
   Then he should not be able to find a ticket with the title 'Sample ticket 4'

Scenario: Youssef can use an Agiil Query to search for tickets
  Given Youssef is looking at the list of tickets
   When he performs an Agiil Query of sprint = "Sprint two" and label = "existing label two"
   Then he should be able to find a ticket with the title 'Sample ticket 6'
    And he should not be able to find a ticket with the title 'Sample ticket 5'
    And he should not be able to find a ticket with the title 'Sample ticket 1'

Feature: Viewing ticket details
  Users should be able to see a detailled view of a single ticket.

Background:
  Given Agiil has just been installed
    And April has set up the simple sample project
    And Youssef is logged into the site as a normal user

Scenario: Youssef can read the description of a ticket
   When Youssef opens a ticket with the title 'Sample ticket 1'
   Then Youssef should see that the ticket description reads 'This ticket has a description'

Scenario: Youssef can see the comments for a ticket listed in chronological order
   When Youssef opens a ticket with the title 'Sample ticket 1'
   Then Youssef should see comments with the following text, in order
  | Comment number one    |
  | Comment number three  |
  | Comment number two    |

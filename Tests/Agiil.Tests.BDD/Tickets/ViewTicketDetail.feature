﻿Feature: Viewing ticket details
  Users should be able to see a detailled view of a single ticket.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can read the description of a ticket
   When Youssef navigates to the ticket with the title 'Sample ticket 1'
   Then he should see that the ticket description reads 'This ticket has a description'

Scenario: Youssef can see the type of a ticket
   When Youssef navigates to the ticket with the title 'Sample ticket 1'
   Then he should see that the ticket type is 'Enhancement'

Scenario: Youssef can see the comments for a ticket listed in chronological order
   When Youssef navigates to the ticket with the title 'Sample ticket 2'
   Then he should see comments with the following text, in order
  | Comment text          |
  | Comment number three  |
  | Comment number four   |
  | Comment number two    |

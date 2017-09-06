Feature: Editing a ticket
  A user should be able to edit an existing ticket when they are logged in.

Background:
  Given Agiil has just been installed
    And April has set up the simple sample project
    And Youssef is logged into the site as a normal user

Scenario: Youssef can edit the title of a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 1' for editing
   When Youssef changes the ticket title to 'This is an edited ticket' and clicks submit
   Then Youssef looks at the list of tickets
    And Youssef should be able to find a ticket with the title 'This is an edited ticket'

Scenario: Youssef can't change the title of a ticket to an empty string
  Given Youssef has opened a ticket with the title 'Sample ticket 1' for editing
   When Youssef changes the ticket title to '' and clicks submit
   Then Youssef should see a ticket-editing error message

Scenario: Youssef can edit the description of a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 1' for editing
   When Youssef changes the ticket description to 'This is an edited description' and clicks submit
   Then Youssef opens a ticket with the title 'Sample ticket 1'
    And Youssef should see that the ticket description reads 'This is an edited description'

Scenario: Youssef can change the description of a ticket to an empty string
  Given Youssef has opened a ticket with the title 'Sample ticket 1' for editing
   When Youssef changes the ticket description to '' and clicks submit
   Then Youssef opens a ticket with the title 'Sample ticket 1'
    And Youssef should see that the ticket description reads ''

Scenario: Youssef can move a ticket to a different sprint
  Given Youssef has opened a ticket with the title 'Sample ticket 1' for editing
   When Youssef changes the ticket sprint to 'Sprint three' and clicks submit
   Then Youssef opens a ticket with the title 'Sample ticket 1'
    And Youssef should see that the ticket is part of the sprint 'Sprint three'

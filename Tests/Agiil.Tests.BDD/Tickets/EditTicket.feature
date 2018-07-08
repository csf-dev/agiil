Feature: Editing a ticket
  A user should be able to edit an existing ticket when they are logged in.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can edit the title of a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket title to 'This is an edited ticket' and clicks submit
   Then he looks at the list of tickets
    And he should be able to find a ticket with the title 'This is an edited ticket'

Scenario: Youssef can't change the title of a ticket to an empty string
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket title to '' and clicks submit
   Then he should see a ticket-editing error message

Scenario: Youssef can edit the description of a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket description to 'This is an edited description' and clicks submit
   Then he navigates to the ticket with the title 'Sample ticket 1'
    And he should see that the ticket description reads 'This is an edited description'

Scenario: Youssef can change the description of a ticket to an empty string
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket description to '' and clicks submit
   Then he navigates to the ticket with the title 'Sample ticket 1'
    And he should see that the ticket description reads ''

Scenario: Youssef can move a ticket to a different sprint
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket sprint to 'Sprint three' and clicks submit
   Then he navigates to the ticket with the title 'Sample ticket 1'
    And he should see that the ticket is part of the sprint 'Sprint three'

Scenario: Youssef can change an enhancement ticket to a bug ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket type to 'Bug' and clicks submit
   Then he navigates to the ticket with the title 'Sample ticket 1'
    And he should see that the ticket type is 'Bug'
  
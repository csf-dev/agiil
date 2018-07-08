Feature: Removing labels from a ticket
  Users should be able to remove labels from tickets when they are not
  desired.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
	
Scenario: Removing a label from a ticket should not cause the label to be deleted
  Given Youssef has navigated to the ticket with the title 'Sample ticket 2' and opened it for editing
    And he has set the ticket labels to read '' and submitted
    And he navigates to the label list page
   When he reads the list of available label names
   Then he should see the label 'existing label one'

Scenario: Removing a label from a ticket should not cause the ticket to be deleted
  Given Youssef has navigated to the ticket with the title 'Sample ticket 2' and opened it for editing
    And he has set the ticket labels to read '' and submitted
   When he looks at the list of tickets
   Then he should be able to find a ticket with the title 'Sample ticket 2'

Scenario: Removing the last ticket from a label should not cause the label to be deleted
  Given Youssef has navigated to the ticket with the title 'Sample ticket 3' and opened it for editing
    And he has set the ticket labels to read '' and submitted
    And he navigates to the label list page
   When he reads the list of available label names
   Then he should see the label 'existing label two'

Scenario: Removing the last ticket from a label should not cause the ticket to be deleted
  Given Youssef has navigated to the ticket with the title 'Sample ticket 3' and opened it for editing
    And he has set the ticket labels to read '' and submitted
   When he looks at the list of tickets
   Then he should be able to find a ticket with the title 'Sample ticket 3'

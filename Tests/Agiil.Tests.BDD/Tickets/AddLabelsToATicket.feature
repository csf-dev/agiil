Feature: Adding labels to a ticket
  Users should be able to add arbitrary labels to tickets in order
  to categorise or sort them.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can add two new labels to a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket labels to read 'Label one, label two' and clicks submit
   Then he navigates to the ticket with the title 'Sample ticket 1'
    And he should see that the ticket has the labels
  | Label name |
  | label one  |
  | label two  |

Scenario: Youssef can add a new label and an existing label to a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket labels to read 'Existing Label,label two' and clicks submit
   Then he navigates to the ticket with the title 'Sample ticket 1'
    And he should see that the ticket has the labels
  | Label name     |
  | existing label |
  | label two      |

Scenario: Youssef can add labels to a ticket as it is being created
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value                     |
  | Title       | A new ticket with labels  |
  | Labels      | Label one , Second label  |
    And he navigates to the ticket with the title 'A new ticket with labels'
   Then he should see that the ticket has the labels
  | Label name     |
  | label one      |
  | second label   |

Feature: Viewing ticket labels
	In order to see which labels are available, and to navigate to the associated tickets,
  a user should be able to view the available ticket labels as a list.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
	
Scenario: Youssef can navigate to the list of labels and sees an existing label
	Given Youssef navigates to the label list page
	 When he reads the list of available label names
	 Then he should see the label 'existing label one'

Scenario: After Youssef has added new labels to a ticket, those labels appear in the list of labels
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
    And he has set the ticket labels to read 'Label one, label two' and submitted
    And he navigates to the label list page
   When he reads the list of available label names
   Then he should see that all of the following labels are included in the list:
  | Label name          |
  | existing label one  |
  | label one           |
  | label two           |

Scenario: Labels should indicate the number of open tickets with which they are associated
  Given Youssef navigates to the label list page
   When he reads the number of open tickets associated with 'existing label one'
   Then he should see that there are 2 tickets associated with the label

Scenario: Labels should indicate the number of closed tickets with which they are associated
  Given Youssef navigates to the label list page
   When he reads the number of closed tickets associated with 'existing label one'
   Then he should see that there is 1 ticket associated with the label

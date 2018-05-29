Feature: Automatic links between tickets in descriptions
	In order to navigate more easily between tickets which mention one another.
  Users should see ticket references typed in markdown render as hyperlinks to the
  mentioned ticket.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
	
Scenario: Youssef can follow a project-qualified ticket link in the description
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket description to 'This is a link to #AG2' and clicks submit
    And he clicks on the link in the ticket description which has the text '#AG2'
   Then he should see that the ticket title reads 'Sample ticket 2'

Scenario: Youssef can follow a naked ticket link in the description
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing
   When he changes the ticket description to 'This is a link to #2' and clicks submit
    And he clicks on the link in the ticket description which has the text '#2'
   Then he should see that the ticket title reads 'Sample ticket 2'

Feature: Commenting on a ticket
  Users should be able to leave comments on a ticket in a chronological discussion thread.
  This will help them expand their understanding of the ticket and collaborate
  on both the requirements and the solution.

Background:
  Given Agiil has just been installed
    And April has set up the simple sample project
    And Youssef is logged into the site as a normal user
  
Scenario: Youssef can add a comment to a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 2'
  When Youssef adds a comment with the text 'Hi there, this is a comment'
   Then Youssef should see comments with the following text, in order
  | Hi there, this is a comment |

Scenario: Youssef cannot add a comment with an empty body
  Given Youssef has opened a ticket with the title 'Sample ticket 2'
  When Youssef adds a comment with the text ''
   Then Youssef should see an add-comment error message

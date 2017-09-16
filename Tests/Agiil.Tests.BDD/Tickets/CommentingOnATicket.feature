Feature: Commenting on a ticket
  Users should be able to leave comments on a ticket in a chronological discussion thread.
  This will help them expand their understanding of the ticket and collaborate
  on both the requirements and the solution.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
  
Scenario: Youssef can add a comment to a ticket
  Given Youssef has opened a ticket with the title 'Sample ticket 3'
   When Youssef adds a comment with the text 'Hi there, this is a comment'
   Then Youssef should see comments with the following text, in order
  | Comment text                |
  | Hi there, this is a comment |

Scenario: Youssef cannot add a comment with an empty body
  Given Youssef has opened a ticket with the title 'Sample ticket 3'
  When Youssef adds a comment with the text ''
   Then Youssef should see an add-comment error message

Scenario: Youssef may edit his own ticket comment
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When Youssef edits the first editable comment
    And Youssef changes the comment text to 'This is an edited comment'
    And Youssef opens a ticket with the title 'Sample ticket 1'
   Then Youssef should see comments with the following text, in order
  | Comment text                |
  | This is an edited comment   |

Scenario: Youssef may add a second comment to a ticket which already has one (AG46)
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When Youssef adds a comment with the text 'Hi there, this is a comment'
   Then Youssef should see comments with the following text, in order
  | Comment text                |
  | Comment number one          |
  | Hi there, this is a comment |

Scenario: Youssef cannot see an edit-comment link for a comment which is not his own
   When Youssef opens a ticket with the title 'Sample ticket 2'
   Then Youssef should not see any editable comments

Scenario: Youssef cannot edit a comment and set its body to an empty string
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When Youssef edits the first editable comment
    And Youssef changes the comment text to ''
   Then Youssef should see a comment-editing failure message

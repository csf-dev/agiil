Feature: Commenting on a ticket
  Users should be able to leave comments on a ticket in a chronological discussion thread.
  This will help them expand their understanding of the ticket and collaborate
  on both the requirements and the solution.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
  
Scenario: Youssef can add a comment to a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 3'
   When he adds a comment with the text 'Hi there, this is a comment'
   Then he should see comments with the following text, in order
  | Comment text                |
  | Hi there, this is a comment |

Scenario: Youssef cannot add a comment with an empty body
  Given Youssef has navigated to the ticket with the title 'Sample ticket 3'
   When he adds a comment with the text ''
   Then he should see an add-comment error message

Scenario: Youssef may edit his own ticket comment
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1'
   When he edits the first editable comment
    And he changes the comment text to 'This is an edited comment'
    And he navigates to the ticket with title 'Sample ticket 1'
   Then he should see comments with the following text, in order
  | Comment text                |
  | This is an edited comment   |

Scenario: Youssef may add a second comment to a ticket which already has one (AG46)
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1'
   When he adds a comment with the text 'Hi there, this is a comment'
   Then he should see comments with the following text, in order
  | Comment text                |
  | Comment number one          |
  | Hi there, this is a comment |

Scenario: Youssef cannot see an edit-comment link for a comment which he did not write
  Given Youssef has navigated to the ticket with the title 'Sample ticket 2'
   Then he should not see any editable comments

Scenario: Youssef cannot edit a comment and set its body to an empty string
  Given Youssef has opened a ticket with the title 'Sample ticket 1'
   When he edits the first editable comment
    And he changes the comment text to ''
   Then he should see a comment-editing failure message

Scenario: Youssef can use markdown syntax in a ticket comment, to create a richly-formatted comment
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1'
   When he edits the first editable comment
    And he changes the comment text to 'This text **should be bold** and _this is italic_.'
   Then he reads the first comment on the ticket 'Sample ticket 1'
    And he should see that the comment text 'should be bold' is displayed in a bold font
    And he should see that the comment text 'this is italic' is displayed in an italic font

Scenario: Youssef may delete his own comment on a ticket
  Given Youssef has navigated to the ticket with the title 'Sample ticket 1'
   When he deletes the first editable comment
    And he navigates to the ticket with title 'Sample ticket 1'
   Then he should see that the ticket has no comments

Scenario: Youssef may not delete comments which he did not write
  Given Youssef has navigated to the ticket with the title 'Sample ticket 2'
   Then he should not see any comments which may be deleted

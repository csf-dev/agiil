Feature: Editing an existing comment on a ticket
  A user should be able to edit their own comments.
  Users cannot edit comments which do not belong to them.
  
Scenario: A user can edit their own comment
  Given the user is logged in with a user account named 'jbloggs'
    And there is a ticket with ID 5
    And ticket ID 5 has the following comments:
  | Id | Author  | Body |
  | 6  | jbloggs | Test |
  When the user submits a request to edit a comment with the following specification:
  | CommentId | Body   |
  | 6         | Sample |
   Then a comment should exist with the following properties:
  | Field    | Value   |
  | Id       | 6       |
  | TicketId | 5       |
  | Author   | jbloggs |
  | Body     | Sample  |

Scenario: A user cannot edit another user's comments
  Given the user is logged in with a user account named 'jbloggs'
    And there is a user account named 'sallyann'
    And there is a ticket with ID 5
    And ticket ID 5 has the following comments:
  | Id | Author   | Body |
  | 6  | sallyann | Test |
  When the user submits a request to edit a comment with the following specification:
  | CommentId | Body   |
  | 6         | Sample |
   Then no comment should exist with the following properties:
  | Field    | Value   |
  | Id       | 6       |
  | Body     | Sample  |

Scenario: A user cannot set a comment's body to an empty string
  Given the user is logged in with a user account named 'jbloggs'
    And there is a user account named 'sallyann'
    And there is a ticket with ID 5
    And ticket ID 5 has the following comments:
  | Id | Author   | Body |
  | 6  | sallyann | Test |
  When the user submits a request to edit a comment with the following specification:
  | CommentId | Body |
  | 6         |      |
   Then no comment should exist with the following properties:
  | Field    | Value   |
  | Id       | 6       |
  | Body     |         |


Scenario: A user cannot edit a comment which does not exist
  Given the user is logged in with a user account named 'jbloggs'
    And there is a user account named 'sallyann'
    And there is a ticket with ID 5
    And ticket ID 5 has the following comments:
  | Id | Author   | Body |
  | 6  | sallyann | Test |
  When the user submits a request to edit a comment with the following specification:
  | CommentId | Body   |
  | 7         | Sample |
   Then no comment should exist with the following properties:
  | Field    | Value   |
  | Id       | 7       |

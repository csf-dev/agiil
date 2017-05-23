Feature: Adding a comment to a ticket
  A user should be able to add a new comment to an existing ticket if they are logged in and the ticket exists.

Scenario: A user can add a comment to a ticket which exists
  Given the user is logged in with a user account named 'jbloggs'
    And there is a ticket with ID 5
   When the user adds a comment with the following specification:
  | TicketId | Body         |
  | 5        | Comment body |
   Then a comment should exist with the following properties:
  | Field    | Value        |
  | TicketId | 5            |
  | Author   | jbloggs      |
  | Body     | Comment body |

Scenario: A user cannot add a comment to a ticket which does not exist
  Given the user is logged in with a user account named 'jbloggs'
    And there is no ticket with ID 5
   When the user adds a comment with the following specification:
  | TicketId | Body         |
  | 5        | Comment body |
   Then no comment should exist with the following properties:
  | Field    | Value        |
  | TicketId | 5            |

Scenario: A user cannot add a comment with an empty body
  Given the user is logged in with a user account named 'jbloggs'
    And there is a ticket with ID 5
   When the user adds a comment with the following specification:
  | TicketId | Body         |
  | 5        |              |
   Then no comment should exist with the following properties:
  | Field    | Value        |
  | TicketId | 5            |
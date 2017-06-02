Feature: Closing and reopening a ticket
  A user should be able to mark a ticket as closed, and then reopen it.

Scenario: A user can mark a ticket as closed.
  Given the user is logged in with a user account named 'jbloggs'
    And there are a number of tickets with the following properties:
  | Id | Title  | Creator | Description                  | Created             |
  | 4  | FooBar | jbloggs | This is a sample description | 2011-01-01 13:20:01 |
   When the user closes ticket ID 4
   Then ticket ID 4 should be closed

Scenario: A user can reopen a closed ticket.
  Given the user is logged in with a user account named 'jbloggs'
    And there are a number of tickets with the following properties:
  | Id | Title  | Creator | Description                  | Created             | Closed |
  | 4  | FooBar | jbloggs | This is a sample description | 2011-01-01 13:20:01 | True   |
   When the user reopens ticket ID 4
   Then ticket ID 4 should be open

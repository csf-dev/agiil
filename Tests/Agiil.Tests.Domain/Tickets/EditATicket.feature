Feature: Editing a ticket
  A user should be able to edit an existing ticket when they are logged in.

Scenario: A user can edit a ticket title and description and save it.
  Given the user is logged in with a user account named 'jbloggs'
    And there are a number of tickets with the following properties:
  | Id | Title  | Creator | Description                  | Created             |
  | 4  | FooBar | jbloggs | This is a sample description | 2011-01-01 13:20:01 |
   When the user requests to edit a ticket title and description with the following specification:
  | Id | Title  | Description           |
  | 4  | Test   | This is a test ticket |
   Then a ticket should exist with the following properties:
  | Field       | Value                 |
  | Id          | 4                     |
  | Title       | Test                  |
  | Description | This is a test ticket |
  | User        | jbloggs               |

Scenario: A user cannot save an edited ticket if they set the title to an empty string
  Given the user is logged in with a user account named 'jbloggs'
    And there are a number of tickets with the following properties:
  | Id | Title  | Creator | Description                  | Created             |
  | 4  | FooBar | jbloggs | This is a sample description | 2011-01-01 13:20:01 |
   When the user requests to edit a ticket title and description with the following specification:
  | Id | Title  | Description           |
  | 4  |        | This is a test ticket |
   Then no ticket should exist matching the following properties:
  | Field       | Value                 |
  | Id          | 4                     |
  | Title       |                       |
  | Description | This is a test ticket |
  | User        | jbloggs               |
    And a ticket should exist with the following properties:
  | Field       | Value                         |
  | Id          | 4                             |
  | Title       | FooBar                        |
  | Description | This is a sample description  |
  | User        | jbloggs                       |

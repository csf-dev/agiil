Feature: Creating a new ticket
  Users should be able to create tickets if they are logged into the web application
  The only mandatory piece of information is the ticket title.
  The created ticket will be stamped with their current user account.
  
Scenario: A user can create a ticket using only a valid title
  Given the user is logged in with a user account named 'jbloggs'
  When the user attempts to create a ticket with the following properties:
  | Field       | Value        |
  | Title       | Ticket title |
  | Description |              |
  Then a ticket should exist with the following properties:
  | Field       | Value        |
  | Title       | Ticket title |
  | Description |              |
  | User        | jbloggs      |

Scenario: A user cannot create a ticket with an empty title
  Given the user is logged in with a user account named 'jbloggs'
  When the user attempts to create a ticket with the following properties:
  | Field       | Value        |
  | Title       |              |
  | Description | Invalid      |
  Then no ticket should exist matching the following properties:
  | Field       | Value        |
  | Description | Invalid      |

Scenario: A user can assign a ticket to a sprint as it is created
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id | Name        |
  | 1  | Test sprint |
  When the user attempts to create a ticket with the following properties:
  | Field     | Value         |
  | Title     | Ticket title  |
  | SprintId  | 1             |
  Then a ticket should exist with the following properties:
  | Field       | Value         |
  | Title       | Ticket title  |
  | Description |               |
  | User        | jbloggs       |
  | Sprint      | 1             |

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
  Then a ticket should be created with the following properties:
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
  Then no ticket should have been created matching the following properties:
  | Field       | Value        |
  | Description | Invalid      |

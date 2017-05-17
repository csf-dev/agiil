Feature: Viewing ticket details
  Users should be able to see a detailled view of a single ticket.
  
Scenario: A user can see the details of a single ticket
  Given the user is logged in with a user account named 'jbloggs'
    And there are a number of tickets with the following properties:
  | Id | Title     | Creator  | Description                  | Created             |
  | 4  | FooBar    | jbloggs  | This is a sample description | 2011-01-01 13:20:01 |
  When the user visits the ticket detail page for ticket ID 4
  Then the following ticket detail should be displayed:
  | Id | Title     | Creator  | Description                  | Created             |
  | 4  | FooBar    | jbloggs  | This is a sample description | 2011-01-01 13:20:01 |

Scenario: A user cannot see a non-existent ticket
  Given the user is logged in with a user account named 'jbloggs'
    And there are a number of tickets with the following properties:
  | Id | Title     | Creator  | Description                  | Created             |
  | 4  | FooBar    | jbloggs  | This is a sample description | 2011-01-01 13:20:01 |
  When the user visits the ticket detail page for ticket ID 5
  Then the user sees a 404 error page

Scenario: Ticket comments are listed with the ticket in chronological order
  Given the user is logged in with a user account named 'jbloggs'
    And there is a user account named 'sallyann'
    And there is a ticket with ID 5
    And ticket ID 5 has the following comments:
  | Author   | Timestamp  | Body     |
  | sallyann | 2006-01-01 | Body one |
  | jbloggs  | 2008-01-01 | Body two |
  | sallyann | 2001-01-01 | Body 3   |
   When the user visits the ticket detail page for ticket ID 5
   Then the following comments should be displayed in order:
  | Author   | Timestamp  | Body     |
  | sallyann | 2001-01-01 | Body 3   |
  | sallyann | 2006-01-01 | Body one |
  | jbloggs  | 2008-01-01 | Body two |
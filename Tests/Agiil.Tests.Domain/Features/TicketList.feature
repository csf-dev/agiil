Feature: Listing the tickets
  Users should be able to see a list of the existing tickets, sorted by creation date.
  
Scenario: A user can see a list of tickets
  Given the user is logged in with a user account named 'jbloggs'
    And there is a user account named 'sallyann'
    And there are a number of tickets with the following properties:
  | Title     | Creator  | Created             |
  | FooBar    | jbloggs  | 2011-01-01 13:20:01 |
  | Wizzpop   | sallyann | 2012-01-01 13:20:01 |
  | Test001   | jbloggs  | 2013-01-01 13:20:01 |
  | Test002   | sallyann | 2011-01-01 13:21:01 |
  When the user visits the ticket list page
  Then the following ticket summaries should be displayed, in order:
  | Title     | Creator  | Created             |
  | Test001   | jbloggs  | 2013-01-01 13:20:01 |
  | Wizzpop   | sallyann | 2012-01-01 13:20:01 |
  | Test002   | sallyann | 2011-01-01 13:21:01 |
  | FooBar    | jbloggs  | 2011-01-01 13:20:01 |

Feature: AssigningATicketToASprint
  Users must be able to assign an existing ticket to an existing sprint,
  as part of editing the ticket.
  
Scenario: Users can assign an existing ticket to an existing sprint
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And there are a number of tickets with the following properties:
  | Ref  | Title  | Creator | Description                  | Created             |
  | XYZ3 | FooBar | jbloggs | This is a sample description | 2011-01-01 13:20:01 |
    And the following sprints exist:
  | Name        | CreationDate  |
  | Test sprint | 2011-01-01    |
  When the user adds ticket XYZ3 to sprint 'Test sprint'
  Then ticket XYZ3 is part of sprint 'Test sprint'

Scenario: Users cannot assign tickets to non-existent sprints
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And there are a number of tickets with the following properties:
  | Ref  | Title  | Creator | Description                  | Created             |
  | XYZ3 | FooBar | jbloggs | This is a sample description | 2011-01-01 13:20:01 |
    And the following sprints exist:
  | Name        | CreationDate  |
  | Test sprint | 2011-01-01    |
  When the user adds ticket XYZ3 to sprint 'Nonexistent sprint'
  Then ticket XYZ3 is not part of any sprint

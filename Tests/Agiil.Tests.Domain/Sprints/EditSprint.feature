Feature: Editing sprints
  Users must be able to edit a sprint and change its title, description and dates.
  
Scenario: Users can edit a sprint's title, description, dates and open/closed state
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id  | Name          | CreationDate  | StartDate   | EndDate     | Closed |
  | 1   | Test sprint 1 | 2011-01-01    | 2015-05-01  | 2016-01-01  | False  |
  When the user attempts to edit a sprint with the following specification:
  | Id  | Name                | Description       | StartDate   | EndDate     | Closed |
  | 1   | SprintyMcSprintFace | This is a sprint  | 2016-05-01  | 2017-01-01  | True  |
  Then a sprint exists with the following details:
  | Field       | Value                 |
  | Name        | SprintyMcSprintFace   |
  | Project     | 1                     |
  | Description | This is a sprint      |
  | StartDate   | 2016-05-01            |
  | EndDate     | 2017-01-01            |

Scenario: A user cannot give a sprint an empty title
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id  | Name          | CreationDate  | StartDate   | EndDate     | Closed |
  | 1   | Test sprint 1 | 2011-01-01    | 2015-05-01  | 2016-01-01  | False  |
  When the user attempts to edit a sprint with the following specification:
  | Id  | Name  | Description       | StartDate   | EndDate     | Closed |
  | 1   |       | This is a sprint  | 2016-05-01  | 2017-01-01  | True   |
  Then no sprint should exist with the following details:
  | Field       | Value                 |
  | Name        |                       |
  | Project     | 1                     |
  | Description | This is a sprint      |
  | StartDate   | 2016-05-01            |
  | EndDate     | 2017-01-01            |

Scenario: A user cannot give a sprint an end date which is before its start date
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id  | Name          | CreationDate  | StartDate   | EndDate     | Closed |
  | 1   | Test sprint 1 | 2011-01-01    | 2015-05-01  | 2016-01-01  | False  |
  When the user attempts to edit a sprint with the following specification:
  | Id  | Name                | Description       | StartDate   | EndDate     | Closed |
  | 1   | SprintyMcSprintFace | This is a sprint  | 2016-05-01  | 2015-01-01  | True  |
  Then no sprint should exist with the following details:
  | Field       | Value                 |
  | Name        | SprintyMcSprintFace   |
  | Project     | 1                     |
  | Description | This is a sprint      |
  | StartDate   | 2016-05-01            |
  | EndDate     | 2015-01-01            |

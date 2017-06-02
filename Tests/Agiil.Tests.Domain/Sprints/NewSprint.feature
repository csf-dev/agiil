Feature: Create a new sprint
  Users must be able to create sprints.
  
Scenario: A user can create a sprint using just a name
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
  When the user creates a sprint with the following details:
  | Field | Value       |
  | Name  | Test sprint |
  Then a sprint exists with the following details:
  | Field       | Value       |
  | Name        | Test sprint |
  | Project     | 1           |
  | Description |             |
  | StartDate   |             |
  | EndDate     |             |

Scenario: A user cannot create a sprint if they omit the name
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
  When the user creates a sprint with the following details:
  | Field       | Value       |
  | Name        |             |
  | StartDate   | 2012-01-01  |
  Then no sprint should exist with the following details:
  | Field       | Value       |
  | StartDate   | 2012-01-01  |

Scenario: A user can create a sprint with a name and start/end dates
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
  When the user creates a sprint with the following details:
  | Field       | Value       |
  | Name        | Test sprint |
  | StartDate   | 2012-01-01  |
  | EndDate     | 2014-01-01  |
  Then a sprint exists with the following details:
  | Field       | Value       |
  | Name        | Test sprint |
  | Project     | 1           |
  | Description |             |
  | StartDate   | 2012-01-01  |
  | EndDate     | 2014-01-01  |

Scenario: A user cannot create a sprint with an end date that is before the start date
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
  When the user creates a sprint with the following details:
  | Field       | Value       |
  | Name        | Test sprint |
  | StartDate   | 2012-01-01  |
  | EndDate     | 2011-01-01  |
  Then no sprint should exist with the following details:
  | Field       | Value       |
  | Name        | Test sprint |


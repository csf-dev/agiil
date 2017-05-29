Feature: Listing sprints
  They should see each sprint with its name, start and end date, in chronological order.
  
Scenario: Sprints with explicit start dates are listed in order of their start date
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id  | Name          | CreationDate  | StartDate   | EndDate     | Closed |
  | 1   | Test sprint 1 | 2011-01-01    | 2015-05-01  | 2016-01-01  | False  |
  | 2   | Test sprint 2 | 2011-01-01    | 2015-03-01  | 2016-01-01  | False  |
  | 3   | Test sprint 3 | 2011-01-01    | 2015-01-01  | 2016-01-01  | False  |
  When the user visits the sprint list page
  Then the following sprints should be listed, in order:
  | Id  | Name          | StartDate   | EndDate     |
  | 3   | Test sprint 3 | 2015-01-01  | 2016-01-01  |
  | 2   | Test sprint 2 | 2015-03-01  | 2016-01-01  |
  | 1   | Test sprint 1 | 2015-05-01  | 2016-01-01  |

Scenario: Sprints which have no start date are ordered by their creation date
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id  | Name          | CreationDate  | StartDate   | EndDate     | Closed |
  | 1   | Test sprint 1 | 2011-01-01    | 2015-05-01  | 2016-01-01  | False  |
  | 2   | Test sprint 2 | 2011-01-01    |             |             | False  |
  | 3   | Test sprint 3 | 2017-01-01    |             |             | False  |
  When the user visits the sprint list page
  Then the following sprints should be listed, in order:
  | Id  | Name          | StartDate   | EndDate     |
  | 2   | Test sprint 2 |             |             |
  | 1   | Test sprint 1 | 2015-05-01  | 2016-01-01  |
  | 3   | Test sprint 3 |             |             |

Scenario: Sprints which are closed do not appear in the listing
  Given the user is logged in with a user account named 'jbloggs'
    And the current project has an ID of 1
    And the following sprints exist:
  | Id  | Name          | CreationDate  | StartDate   | EndDate     | Closed |
  | 1   | Test sprint 1 | 2011-01-01    | 2015-05-01  | 2016-01-01  | False  |
  | 2   | Test sprint 2 | 2011-01-01    |             |             | True   |
  When the user visits the sprint list page
  Then the following sprints should be listed, in order:
  | Id  | Name          | StartDate   | EndDate     |
  | 1   | Test sprint 1 | 2015-05-01  | 2016-01-01  |

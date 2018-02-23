Feature: Editing a sprint
  In order to update the details of a sprint, users must be able to edit it.
  
Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can edit the title, description, start and end dates of a sprint
  Given Youssef has opened the sprint listing page
    And he begins editing the sprint titled 'Sprint three'
   When he enters the following sprint details and clicks submit
  | Field       | Value                 |
  | Title       | Edited sprint 3       |
  | Description | Edited description 3  |
  | StartDate   | 2001-06-05            |
  | EndDate     | 2001-08-05            |
    And he views the sprint titled 'Edited sprint 3'
   Then he should see that the sprint has the following details
  | Field       | Value                 |
  | Title       | Edited sprint 3       |
  | Description | Edited description 3  |
  | StartDate   | 2001-06-05            |
  | EndDate     | 2001-08-05            |

Scenario: Youssef cannot set the title of a sprint to an empty string
  Given Youssef has opened the sprint listing page
    And he begins editing the sprint titled 'Sprint three'
   When he enters the following sprint details and clicks submit
  | Field       | Value |
  | Title       |       |
   Then he should see a sprint-editing failure message

Scenario: Youssef cannot edit the start date of a sprint to be before its end date
  Given Youssef has opened the sprint listing page
    And he begins editing the sprint titled 'Sprint three'
   When he enters the following sprint details and clicks submit
  | Field       | Value       |
  | StartDate   | 2001-06-05  |
  | EndDate     | 2001-04-05  |
   Then he should see a sprint-editing failure message

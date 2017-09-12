Feature: Creating a new sprint
  So that users can organise tickets by the self-contained sprint in which
  they will be resolved.  Users must be able to create a new sprints.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
  
Scenario: Youssef can create a new sprint with just a title
  Given Youssef has opened the new sprint page
   When Youssef enters the following sprint details and presses submit
  | Field | Value                         |
  | Title | New sprint created by Youssef |
    And Youssef opens the sprint listing page
   Then Youssef should see the following sprints
 | Sprint three                   |
 | Sprint one                     |
 | New sprint created by Youssef  |

Scenario: Youssef cannot create a sprint with an empty title
  Given Youssef has opened the new sprint page
   When Youssef enters the following sprint details and presses submit
  | Field | Value                         |
  | Title |                               |
   Then Youssef should see a create-sprint failure message

Scenario: Youssef can assign a start and end date to a sprint as it is created
  Given Youssef has opened the new sprint page
   When Youssef enters the following sprint details and presses submit
  | Field     | Value                         |
  | Title     | New sprint created by Youssef |
  | StartDate | 2014-01-01                    |
  | EndDate   | 2014-02-01                    |
    And Youssef opens the sprint listing page
   Then Youssef should see that the sprint titled 'New sprint created by Youssef' starts on 2014-01-01
    And Youssef should see that the sprint titled 'New sprint created by Youssef' ends on 2014-02-01

Scenario: Youssef can set the description of a sprint as it is created
  Given Youssef has opened the new sprint page
   When Youssef enters the following sprint details and presses submit
  | Field       | Value                           |
  | Title       | New sprint created by Youssef   |
  | Description | This is the sprint description  |
    And Youssef opens the sprint listing page
   Then Youssef should see that the sprint titled 'New sprint created by Youssef' has the description 'This is the sprint description'

Scenario: Youssef cannot give a new sprint a start date which is after its end date
  Given Youssef has opened the new sprint page
   When Youssef enters the following sprint details and presses submit
  | Field     | Value                         |
  | Title     | New sprint created by Youssef |
  | StartDate | 2014-03-01                    |
  | EndDate   | 2014-02-01                    |
   Then Youssef should see a create-sprint failure message

﻿Feature: Creating a new sprint
  So that users can organise tickets by the self-contained sprint in which
  they will be resolved.  Users must be able to create a new sprints.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
  
Scenario: Youssef can create a new sprint with just a title
  Given Youssef has opened the new sprint page
   When he enters the following sprint details and presses submit
  | Field | Value                         |
  | Title | New sprint created by Youssef |
    And he opens the sprint listing page
   Then he should see the following sprints
  | Sprint name                    |
  | New sprint created by Youssef  |

Scenario: Youssef cannot create a sprint with an empty title
  Given Youssef has opened the new sprint page
   When he enters the following sprint details and presses submit
  | Field | Value                         |
  | Title |                               |
   Then he should see a create-sprint failure message

Scenario: Youssef can assign a start and end date to a sprint as it is created
  Given Youssef has opened the new sprint page
   When he enters the following sprint details and presses submit
  | Field     | Value                         |
  | Title     | New sprint created by Youssef |
  | StartDate | 2014-01-01                    |
  | EndDate   | 2014-02-01                    |
    And he opens the sprint listing page
   Then he should see that the sprint titled 'New sprint created by Youssef' starts on 2014-01-01
    And he should see that the sprint titled 'New sprint created by Youssef' ends on 2014-02-01

Scenario: Youssef cannot give a new sprint a start date which is after its end date
  Given Youssef has opened the new sprint page
   When he enters the following sprint details and presses submit
  | Field     | Value                         |
  | Title     | New sprint created by Youssef |
  | StartDate | 2014-03-01                    |
  | EndDate   | 2014-02-01                    |
   Then he should see a create-sprint failure message

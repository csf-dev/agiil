Feature: Viewing sprints
  In order to see the available sprints, users should be able to see an ordered list of the open sprints.

# This feature is also covered in more detail by the unit test SprintListerTests
# That test covers more of the possible combinations of how the component which creates the
# sprint listing builds its query.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project

Scenario: Youssef can see a list of the open sprints
  When Youssef opens the sprint listing page
  Then Youssef should see the following sprints, in order
  | Sprint name  |
  | Sprint three |
  | Sprint one   |

Scenario: Youssef can see a list of the closed sprints
  When Youssef opens the sprint listing page for closed sprints
  Then Youssef should see the following sprints, in order
  | Sprint name  |
  | Sprint two |

Scenario: Youssef can see a list of the open tickets in a sprint
    Given Youssef was able to open the sprint titled 'Sprint one'
     When Youssef reads the open tickets in this sprint
     Then Youssef should see the following tickets, in any order:
  | Ticket name     |
  | Sample ticket 1 |
  | Sample ticket 2 |
  | Sample ticket 3 |

Scenario: Youssef can see a list of the closed tickets in a sprint
    Given Youssef was able to open the sprint titled 'Sprint one'
     When Youssef reads the closed tickets in this sprint
     Then Youssef should see the following tickets, in any order:
  | Ticket name     |
  | Sample ticket 4 |

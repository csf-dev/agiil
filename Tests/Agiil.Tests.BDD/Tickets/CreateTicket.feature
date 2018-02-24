Feature: Creating a new ticket
  Users should be able to create tickets if they are logged into the web application
  The only mandatory piece of information is the ticket title.
  The created ticket will be stamped with their current user account.

Background:
  Given Youssef is logged into a fresh installation of the site containing the simple sample project
  
Scenario: Users should be able to create a ticket with a title and description
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value               |
  | Title       | Ticket title        |
  | Description | Ticket description  |
   Then he should see a ticket created success message

Scenario: Users should be able to create a ticket with just a title
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value               |
  | Title       | Ticket title        |
   Then he should see a ticket created success message

Scenario: A user should be able to find the ticket they just created
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value               |
  | Title       | Create ticket 1     |
  | Description | Ticket description  |
    And he looks at the list of tickets
   Then he should be able to find a ticket with the title 'Create ticket 1'

Scenario: Users are marked as the creator of the tickets they create
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value               |
  | Title       | Create ticket 2     |
  | Description | Ticket description  |
    And he navigates to the ticket with the title 'Create ticket 2'
   Then he should see that the creator of the current ticket is 'Youssef'

Scenario: The ticket description must be saved when a ticket is created
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value               |
  | Title       | Create ticket 3     |
  | Description | Ticket description  |
    And he navigates to the ticket with the title 'Create ticket 3'
   Then he should see that the ticket description reads 'Ticket description'

Scenario: Users cannot create tickets with an empty title
   When Youssef creates the following ticket using the create ticket page
  | Field       | Value        |
  | Title       |              |
  | Description | Invalid      |
   Then he should see a ticket creation failure message

Scenario: Users can choose sprints for a tickets as they create them
   When Youssef creates the following ticket using the create ticket page
  | Field     | Value             |
  | Title     | Create ticket 4   |
  | Sprint    | Sprint one        |
    And he navigates to the ticket with the title 'Create ticket 4'
   Then he should see that the ticket is part of the sprint 'Sprint one'

Scenario: Youssef can create enhancement tickets
   When Youssef creates the following ticket using the create ticket page
  | Field     | Value             |
  | Title     | Create ticket 4   |
  | Type      | Enhancement       |
    And he navigates to the ticket with the title 'Create ticket 4'
   Then he should see that the ticket type is 'Enhancement'

Scenario: Youssef can create bug tickets
   When Youssef creates the following ticket using the create ticket page
  | Field     | Value             |
  | Title     | Create ticket 4   |
  | Type      | Bug               |
    And he navigates to the ticket with the title 'Create ticket 4'
   Then he should see that the ticket type is 'Bug'

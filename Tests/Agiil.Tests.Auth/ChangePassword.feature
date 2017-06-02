Feature: A user changing their own password
  Users should be able to change their own password if they are logged in.

Scenario: The user can change their own password if they get the details right
  Given the user is logged in with a user account named 'johndoe' with password 'secret'
   When the user submits a request to change their password with the following details:
  | Field                     | Value   |
  | ExistingPassword          | secret  |
  | NewPassword               | wibble  |
  | NewPasswordConfirmation   | wibble  |
    And the user logs out
    And the user attempts to log in with a username 'johndoe' and password 'wibble'
   Then the user is logged in successfully  


Feature: Seeing the application version number
  So that users can communicate about their current installed application version
  and to ease the burden on administrators who wish to know which version of the
  application they are using.  Any user should be able to see the application version
  in the page footer.
  
Background:
  Given Youssef is logged into a fresh installation of the site

Scenario: Read the version number
  Given April overrides the application version number to 'v1.2.3'
  When Youssef reads the version number from the application footer
  Then he should see that the version number is 'v1.2.3'
   And April should clear the application version number override

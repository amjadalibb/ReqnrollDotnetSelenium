Feature: Login

  In order to use the Advantage Shopping site
  As a user
  I want to be verify Login feature with valid credentials

@Login @smoketest @regressiontest
Scenario: Test login with valid credentials
	Given I navigate to Advantage Shopping site
	When I click on the login link
	And I enter valid username and password
	And I click Sign In

Feature: Register

In order to use the Advantage Shopping site
  As a user
  I want to be verify Register Account with different sets of data
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Empty Username
	Given I am on Register page
	When I enter username "" and email "abc@adv.com" and password "password123" and confirm password "password123"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Username field is required" for username field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Short Username
	Given I am on Register page
	When I enter username "abc" and email "abc@adv.com" and password "password123" and confirm password "password123"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Use 5 character or longer" for username field

@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Empty Email
	Given I am on Register page
	When I enter username "abcdef" and email "" and password "password123" and confirm password "password123"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Email field is required" for email field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Incorrect Email
	Given I am on Register page
	When I enter username "abcdef" and email "abc" and password "password123" and confirm password "password123"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Your email address isn't formatted correctly" for email field

@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Empty Password
	Given I am on Register page
	When I enter username "abcdef" and email "abc@adv.com" and password "" and confirm password "password123"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Password field is required" for password field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Short Password
	Given I am on Register page
	When I enter username "abcde" and email "abc@adv.com" and password "abc" and confirm password "abc"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Use 4 character or longer" for password field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account Without Upper Letter in Password
	Given I am on Register page
	When I enter username "abcdef" and email "abc@adv.com" and password "abcdef" and confirm password "abcdef"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "One upper letter required" for password field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account Without Lower Letter in Password
	Given I am on Register page
	When I enter username "abcdef" and email "abc@adv.com" and password "ABCDEF1" and confirm password "ABCDEF1"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "One lower letter required" for password field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account Without Number in Password
	Given I am on Register page
	When I enter username "abcdef" and email "abc@adv.com" and password "Password" and confirm password "Password"  
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "One number required" for password field
	
@CreateNewAccount @smoketest @regressiontest
Scenario: Create New Account With Empty Confirm Password
	Given I am on Register page
	When I enter username "abcdef" and email "abc@adv.com" and password "Password123" and confirm password "" 
	And I Agree to the conditions of Use and Privacy Notice
	Then I should see error message "Confirm password field is required" for confirm password field
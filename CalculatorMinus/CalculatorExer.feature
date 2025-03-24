@mytag
Feature: Windows Calculator Operations

  As a user
  I want to use the Windows calculator for various operations
  And validate its functionality with SpecFlow examples

 Scenario Outline: Perform basic arithmetic operations
    Given I open the Windows calculator app
    Given I have entered <FirstNumber> into the calculator
    When I press <Operation>
    Given I have entered <SecondNumber> into the calculator
    When I hit the equals button
    Then the result should be <ExpectedResult> on the screen
    Then I close the Windows calculator app
    Examples:
      | FirstNumber | SecondNumber | Operation | ExpectedResult |
      | 50          | 70           | add       | 120            |
      | 100         | 30           | subtract  | 70             |
      | 15          | 10           | multiply  | 150            |
      | 100         | 25           | divide    | 4              |
      

Feature: Google
    In order to search the internet
    As an internet user
    I want some sort of engine I can ask questions and get answers

Scenario: I can search for things 
    Given I have navigated to Google 
    And I have entered "Wikipedia" into the search bar
    When I hit Enter
    Then I should be redirected to the Search Results page
    And the first result should be www.wikipedia.org

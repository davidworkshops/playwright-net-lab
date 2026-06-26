Feature: Playwright homepage

  Scenario: Homepage has Playwright in title
    Given the user opens the Playwright homepage
    Then the page title contains "Playwright"
Feature: Add and update Customer

Assumptions:
    * Saved means a model has an Id above zero

Scenario: Add a Customer
    Given a new Customer
    And the Customer Firstname is 'Vic'
    And the Customer Surname is 'Reeves'
    When I click Save
    Then the Customer is saved
    And the Customer is listed

Scenario: Update an existing Customer
    Given an exsiting Customer
    And the Customer is listed
    And the Customer Firstname is 'Vic'
    And the Customer Surname is 'Reeves'
    When I change the Customer Firstname to 'Bob'
    And I change the Customer Surname to 'Mortimer'
    And I click Save
    Then the Customer is saved
    And the Customer is listed

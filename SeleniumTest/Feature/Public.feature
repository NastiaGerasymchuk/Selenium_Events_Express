Feature: Public
	authorized user want to have possibility to create public event, So  every users can join to event without his/her approving

@Public
Scenario: Create public event
Given I am authorised user <email>,<password>
And on add event page
When I set valid values of all requred fields <photo>, <title>,<description>, <category>, position on the map)
And choose pubic event
And click save button
Then event will be created
And I am redirected to home page
And I see created event
And Every users can join to event without my approving
Examples: 
	| photo            | title         | description          | category | email           | password |
	| Desktop\\example.jpg | add new event | some new description | Golf     | admin@gmail.com | 1qaz1qaz |
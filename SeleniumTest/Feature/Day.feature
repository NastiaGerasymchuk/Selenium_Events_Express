Feature: Day
	Authorized user want to have possibility to create daily recurent event, So his/her created event will repeat for several days

@Day
Scenario: Create day recurent event
Given I am authorised   user <email>,<password>
And on add  event page
When  I set value of all requred fields(<photo>, <title>,<description>, <category>, position on the map)
Then periodicity dropdown option and frequency aren't visible
And choose recurent event
Then periodicity dropdown option and frequency are visible
And choose Daily option in periodicity dropdown
And choose frequency <frequency>
And choose date from field <dateFrom>
And click  save button
Then  event  will be created
And  I  am redirected to home page
And I  see created event
And created event will be from chosen date for chosen count of days
Examples: 
| photo                | title         | description          | category | email           | password | frequency | dateFrom |
| Desktop\\example.jpg | add new event | some new description | Golf     | admin@gmail.com | 1qaz1qaz | 6         | 3        |

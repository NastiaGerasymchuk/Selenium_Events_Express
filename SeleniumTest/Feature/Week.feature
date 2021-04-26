Feature: Week
	this test gives oppotunity authorized system user to create week periodical event

@Week
Scenario: Create week recurent event
When I set value  of all requred fields(<photo>, <title>,<description>, <category>, position on the map)
Then periodicity dropdown option and count of days aren't visible
And choose  recurent event
Then periodicity dropdown option and count of days are visible
And choose Weekly option
And choose count of weeks <frequency>
And choose date from  field <dateFrom>
And choose date to field <dateTo>
And click save  button
Then event  will  be created
And I am  redirected to home page
And I see created  event
Then I create event, which will be from chosen from date from to chosen date to for chosen count of weeks
Then quit    browser
Examples: 
| photo                | title         | description          | category | frequency | dateFrom | dateTo |
| Desktop\\example.jpg | add new event | some new description | Golf     | 6         | 3        |   8     |
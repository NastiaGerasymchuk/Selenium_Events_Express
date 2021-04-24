Feature: Online
	this test gives oppotunity authorized system user to create online  event

@Online
Scenario:  Create online event
Given I am authorised  user <email>,<password>
And on  add event page
When I set   photo field <photoPath>
And type  title fiele <title>
And type  description  field <description>
And choose  category  field <category>
And map   field lights red
And choose online option 
Then  online   field ligths red
And type online  field <onlinePath>
And online  field  doesn't ligth red
And click  save   button
Then event   will be created
And user   is redirected to home page
Examples: 
| email | password | photoPath | title | description | category | onlinePath |
|admin@gmail.com | 1qaz1qaz | Desktop\\example.jpg | add new event | some new description | Golf     | https://www.w3.org/TR/CSS21/selector.html%23id-selectors |

Feature: CreatingEventWithRequiredFiles,Create event with required values	
	this test gives oppotunity authorized system user to create event with minimum filling of fields
	 Background:
     Given   unauthorised  user
	 When I   authorised   with
	 
	 | email | password |
	 |admin@gmail.com | 1qaz1qaz |
	 And go   to add  event page
Scenario Outline: Create event with required values	
When I set photo  field <photoPath>  
	And type  title field <title>  
	And type description field  <description>
	And choose category field <category>
	Then map field ligths red
	And choose position on the map field 
	Then  map doesn't ligth red
	And click save button
	Then event will  be created
	And user is redirected to home page
	Then  quit  browser
	Examples: 
	| photoPath            | title         | description          | category| 
	| Desktop\\example.jpg | add new event | some new description | Golf     | 


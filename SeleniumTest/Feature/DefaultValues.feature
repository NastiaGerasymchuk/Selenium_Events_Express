Feature: DefaultValues
Description: this test revise all default values of fields
	

@DefaultValues
Scenario:  Default values
    Given unauthorised user
	When I authorised with <email>,<password>
	And go to add event page
    Then I see photo field is empty
	And title is empty
	And max count of participants is empty
	And reccurent event field is unchecked
	And public field is unchecked
	And date field is current date
	And description is empty
	And hashtags field is empty
	And map option is chosed
	And online option is unchosed
	And position on the map field isn't chosen
	And list of inventories is collapsed
	Then quit browser
	Examples:
    | email | password |
    | admin@gmail.com | 1qaz1qaz |
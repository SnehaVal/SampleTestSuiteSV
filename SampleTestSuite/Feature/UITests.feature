Feature: UTTests

@Buy
Scenario: Buy gas of given quantity
	Given the landing page is loaded	
	And the buy energy link is selected
	When I enter the quantity for gas and click on Buy
	| Key      | Value |
	| quantity | 5     |
	Then the purchase is successful


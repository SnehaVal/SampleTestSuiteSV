Feature: APITests

@logon
Scenario: Successful logon using API
	Given the user is logged on using API

@reset
Scenario: Reset the test data
	When the test data is reset
	Then the response is returned as success

@EnergyDetails
Scenario: Fetch the energy details
	When the energy details is requested using API
	Then the energy details is retrieved successfully 

@BuyEnergyType
Scenario Outline: Buy energy of each type
	Given the energy details is requested using API
	When the <EnergyType> of <Quantity> is purchased using API
	Then the purchased should be successful
	Examples:
	| EnergyType | Quantity |
	| electric   | 2        |
	| gas        | 3        |
	| nuclear    | 4        |
	| oil        | 5        |

@OrderDetails
Scenario Outline: Fetch the order details created
	Given the energy details is requested using API
	And the <EnergyType> of <Quantity> is purchased using API
	When the order details is requested using API
	Then the order details is retrieved successfully 
	Examples:
	| EnergyType | Quantity |
	| electric   | 6        |
	| gas        | 7        |
	| nuclear    | 8        |
	| oil        | 9        |

@OrderDetails
Scenario: Fetch the order details created prior to the current day
	Given the order details is requested using API
	Then the number of orders created prior to the current day is calculated
	 
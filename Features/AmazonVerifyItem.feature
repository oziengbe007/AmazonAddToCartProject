Feature: AmazonVerifyItem

A short summary of the feature

@e2eTest
Scenario Outline: Verify Product on Amazon
	Given I am on amazon
	When I search for <searchKey>
	When I select item
	And I add item to cart
	Then I verify the item name and price

	Examples: 
	| searchKey |
	| TP-Link N450 WiFi Router - Wireless Internet Router for Home(TL-WR940N) |
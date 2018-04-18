Feature: Resource Transaction

Scenario: A resource will be able to create a transaction
	Given Resource "Employee" add a transaction
	When Add by resource "Employee" transaction description "Trans" amount 500 type "Money"
	Then Result will be transaction id not empty

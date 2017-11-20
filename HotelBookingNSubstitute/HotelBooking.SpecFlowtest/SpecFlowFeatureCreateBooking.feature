Feature: SpecFlowFeatureCreateBooking
		As a Guest 
		I want to make bookings
		so that I am sure I have the rooms i need

@mytag
Scenario Outline: Create Booking
	Given I have the entered a <StartDate> startDate
	And I have also entered a <EndDate> endDate
	And There are available rooms 
	When I press Create
	Then A new booking should be created
	Examples: 
	| Id | StartDate  | EndDate    | CustomerId | RoomId |
	| 0  | 2017-11-18 | 2017-11-23 | 1          | 1      |
	| 1  | 2017-11-18 | 2017-11-22 | 2          | 2      |
	
	
	

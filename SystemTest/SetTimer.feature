Feature: SetTimer
	I want to cook or heat my food 
	in the duration of the correct time

@timer1
Scenario: Set time once
	Given The oven is reset
	And I have pressed power button 1 time(s)
	When I press the timer button 1 time(s)
	Then the display shows 01:00

@timer2
Scenario: Set time twice
	Given The oven is reset
	And I have pressed power button 1 time(s)
	When I press the timer button 2 time(s)
	Then the display shows 02:00

@timer60
Scenario: Set time 60
	Given The oven is reset
	And I have pressed power button 1 time(s)
	When I press the timer button 60 time(s)
	Then the display shows 60:00
Feature: MicroPowerOnce
	I want to cook or heatmy food 
	at the correct power

@power1
Scenario: Set Power Once
	Given the oven is reset
	When I press the power button 1 time(s)
	Then the display show 50 W

@power2
Scenario: Set Power Twice
	Given the oven is reset
	When I press the power button 2 time(s)
	Then the display show 100 W

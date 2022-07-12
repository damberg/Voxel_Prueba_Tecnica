Feature: GameConditions

A short summary of the feature

@tag1
	Scenario: player cant be added in started game 
	

	Scenario: player can be added in stoped game 
	Given An not started game
	When add a new player  
	Then the start result is true

	
	Scenario: A game with no players cant start  
	Given a game with 0 players is not started  
	Then you cant start a game
	
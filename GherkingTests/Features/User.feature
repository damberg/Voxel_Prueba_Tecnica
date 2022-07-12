Feature: StartPosition

A short summary of the feature

@tag1
Scenario: Game is started
	Given the token is placed on the board
	Then the token is on square 1

Scenario: Players cant be added in started game	
	Given the game is started
	When add a new player
	Then the start result is false

Scenario: Players move their token in the game
	Given the token is on square 1
	When the token is moved 3 spaces
	And then it is moved 4 spaces
	Then the token is on square 8

Scenario: Player move their token in the game
	Given the token is on square 1
	When the token is moved 3 spaces
	Then the token is on square 4

Scenario: Player Can Win the Game
	Given the token is on square 97
	When the token is moved 3 spaces
	Then the token is on square 100
	And the player has won the game

Scenario: Player need be in the 100 position to win
	Given the token is on square 97
	When the token is moved 4 spaces
	Then the token is on square 97
	And the player has not won the game

Scenario: Dice results must be between 1-6
	Given the game is started
	When the player rolls a dice
	Then the result should be between 1-6 inclusive

Scenario: Player token moves the dice result
	Given the player rolls a 4
	When they move their token
	Then the token should move 4 spaces
 




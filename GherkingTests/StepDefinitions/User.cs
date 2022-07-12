using Voxel_Prueba_Tecnica.Enums;
using Voxel_Prueba_Tecnica.Models;
namespace GherkingTests.StepDefinitions
{
	[Binding]
	public sealed class User
	{
		GameController _gameController =  new GameController();
		int _previusPosition = 0;
		int _rolResult = 0;
		public User()
		{
			_gameController.AddPlayer("Daniel");
			_gameController.AddPlayer("Manuel");
			_gameController.StartGame();
		}

		[Given(@"the token is placed on the board")]
		public void GivenTheTokenIsPlacedOnTheBoard()
		{
			
		}


		[Then(@"the token is on square (.*)")]
		public void ThenTheTokenIsOnSquare(int p0)
		{
			_gameController.GetCurrentPlayerTokenPosition().Should().Be(p0);
		}

		[Given(@"the token is on square (.*)")]
		public void GivenTheTokenIsOnSquare(int p0)
		{
			_gameController._playersManager.PutCurrentPlayerInPosition(p0);
		}

		[When(@"the token is moved (.*) spaces")]
		public void WhenTheTokenIsMovedSpaces(int p0)
		{
			_gameController._playersManager.Move(p0);
		}

		[When(@"then it is moved (.*) spaces")]
		public void WhenThenItIsMovedSpaces(int p0)
		{
			_gameController._playersManager.Move(p0);
		}

		[Then(@"the player has not won the game")]
		public void ThenThePlayerHasNotWonTheGame()
		{
			_gameController.StatusAfterPlay(_gameController.GetCurrentPlayerTokenPosition()).Should().NotBe(State.Finished);
		}

		[Then(@"the player has won the game")]
		public void ThenThePlayerHasWonTheGame()
		{
			_gameController.StatusAfterPlay(_gameController.GetCurrentPlayerTokenPosition()).Should().Be(State.Finished);
		}

		[When(@"the player rolls a dice")]
		public void WhenThePlayerRollsADie()
		{
			_rolResult = Dice.Roll();
			
		}

		[Then(@"the result should be between 1-6 inclusive")]
		public void ThenTheResultShouldBeBetweenInclusive()
		{
			_rolResult.Should().BeInRange(1, 6);
		}

		[Given(@"the player rolls a (.*)")]
		public void GivenThePlayerRollsA(int p0)
		{
			_rolResult = p0;
		}

		[When(@"they move their token")]
		public void WhenTheyMoveTheirToken()
		{
			_previusPosition = _gameController._playersManager.GetCurrentPlayerTokenPosition();
			_gameController._playersManager.Move(_rolResult);
		}

		[Then(@"the token should move (.*) spaces")]
		public void ThenTheTokenShouldMoveSpaces(int p0)
		{
			(_gameController.GetCurrentPlayerTokenPosition() - _previusPosition).Should().Be(p0);
		}

	}
}
using Voxel_Prueba_Tecnica.Enums;
using Voxel_Prueba_Tecnica.Models;
namespace GherkingTests.StepDefinitions
{
	[Binding]
	public sealed class Game
	{
		GameController _gameController { get; set; } = new GameController();
		bool _isuserAdded { get; set; } = false;

		

		[Given(@"trying to insert new user")]
		public void GivenTryingToInsertNewUser()
		{
			_gameController.AddPlayer("daniel");
			_gameController.AddPlayer("daniel2");
			_gameController.StartGame();
		}

		[Given(@"the game is started")]
		public void GivenTheGameIsStarted()
		{
			_gameController.AddPlayer("daniel");
			_gameController.AddPlayer("daniel2");
			_gameController.StartGame();
		}
		
		[Given(@"An not started game")]
		public void GivenAnNotStartedGame()
		{
			
		}

		[When(@"add a new player")]
		public void WhenAddANewPlayer()
		{
			_isuserAdded = _gameController.AddPlayer("test");
		}


		[Given(@"a game with (.*) players is not started")]
		public void GivenAGameWithPlayersIsNotStarted(int p0)
		{
			for (int i = 0; i < 0; i++)
			{
				_gameController.AddPlayer(i.ToString());
			}
		}

		[Then(@"the start result is (.*)")]
		public void ThenTheResultIsFalse(bool state)
		{
			_isuserAdded.Should().Be(state);
		}

		[Then(@"you cant start a game")]
		public void ThenYouCantStartAGame()
		{
			_gameController.StartGame().Should().Be(State.Stoped);
		}





	}
}
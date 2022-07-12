using Voxel_Prueba_Tecnica.Enums;

namespace Voxel_Prueba_Tecnica.Models
{
	public class ConsoleController
	{
		GameController _gameController { get; set; } = new GameController();
		public void GetPlayerName()
		{
			Console.WriteLine("Plase enter the player's name");
			var userName = Console.ReadLine();

			if (string.IsNullOrEmpty(userName))
			{
				GetPlayerName();
			}		

			_gameController.AddPlayer(userName);
			ShowMessageAddPlayer();
		}

		public void Play()
		{
			if (_gameController.GetGameState() != State.Stoped)
			{
				Console.WriteLine("Pres any key to roll");
				Console.ReadKey();
				if (_gameController.Play() != State.Finished)
				{
					var tokenPosition = _gameController.GetPreviusPlayerTokenPosition();
					var currentPlayer = _gameController.GetPreviusPlayerTokenNumber();
					ShowPlayerPosition(currentPlayer, tokenPosition);
				}

				ShowWinner(_gameController.GetCurrentPlayer());
			}
			else 
			{
				ShowMessageAddPlayer();
			}
		}

		public void ShowPlayerPosition(int player, int playerPos)
		{
			Console.WriteLine("The position of player {0} is {1}", player, playerPos);
			Play();

		}

		public void ShowMessageAddPlayer()
		{
			Console.WriteLine("Players name: {0}", _gameController.GetPlayersName());
			Console.WriteLine("Press 0 for add player, press 1 to start (min 2 players required)");
			int option = 0;
			var key = Console.ReadLine();
			if (int.TryParse(key, out option))
			{
				if ((Options)option == Options.AddPlayer)
				{
					GetPlayerName();
				}

				if ((Options)option == Options.Start)
				{
					_gameController.StartGame();
					Play();
				}
			}

			else
			{
				ShowMessageAddPlayer();
			}
		}

		public static int AskNumberPlayers()
		{
			Console.WriteLine("Plase Write number of players");
			var numberPlayersResult = Console.ReadLine();

			int numberPlayer = 0;
			bool success = int.TryParse(numberPlayersResult, out numberPlayer);

			if (!success)
				return AskNumberPlayers();

			return (numberPlayer);
		}

		public void ShowWinner(int player)
		{
			Console.WriteLine("The winner is the player {0}", player);
			Console.ReadLine();
		}
	}
}

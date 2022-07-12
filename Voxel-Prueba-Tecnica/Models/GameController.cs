
using Voxel_Prueba_Tecnica.Enums;

namespace Voxel_Prueba_Tecnica.Models
{
	public class GameController
	{
		public GameManager _game { get; set; } = new GameManager();
		public PlayersManager _playersManager { get; set; } = new PlayersManager();
		public State StartGame()
		{
			return _game.StartGame(_playersManager.GetNumberPlayers());
		}

		public bool AddPlayer(string name)
		{
			if (_game.GetState() == State.Stoped)
			{
				_playersManager.AddPlayer(name);
				return true;
			}

			return false;
		}

		public int GetCurrentPlayerTokenPosition()
		{
			return _playersManager.GetCurrentPlayerTokenPosition();
		}

		public int GetPreviusPlayerTokenPosition()
		{
			return _playersManager.GetPreviusPlayerTokenPosition();
		}

		public int GetPreviusPlayerTokenNumber()
		{
			return _playersManager.GetPreviusPlayerTokenNumber();
		}

		public string GetPlayersName()
		{
			return _playersManager.GetPlayersName();
		}

		public int GetCurrentPlayer()
		{
			return _playersManager._currentPlayer;
		}

		public State GetGameState()
		{
			return _game.GetState();
		}

		public int MoveCurrentPlayer(int steps)
		{
			return _playersManager.Move(steps);
		}

		public State StatusAfterPlay(int newPosition)
		{
			return _game.StatusAfterPlay(newPosition);
		}

		public State Play()
		{
			var state = _game.GetState();
			if (state != State.Started)
			{
				return state;
			}
			
			var newPosition = _playersManager.Move(Dice.Roll());
			state = _game.StatusAfterPlay(newPosition);
			if (state == State.Finished)
			{
				return state;
			}

			_playersManager.NextPlayer();
			return state;
		}
	}
}

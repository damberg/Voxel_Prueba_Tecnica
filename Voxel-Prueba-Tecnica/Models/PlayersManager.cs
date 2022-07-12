using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voxel_Prueba_Tecnica.Models
{
	public class PlayersManager
	{
		public int _currentPlayer { get; set; } = 0;
		public List<Player> _players { get; set; } = new List<Player>();

		public void AddPlayer(string name)
		{
			_players.Add(new Player(name));
		}

		public int NextPlayer()
		{
			if (_currentPlayer != _players.Count -1 )
			{
				_currentPlayer = _currentPlayer + 1;
				return _currentPlayer;
			}

			_currentPlayer = 0;
			return _currentPlayer;
		}
		

		public int GetNumberPlayers()
		{ 
			return this._players.Count; 
		}

		public int GetCurrentPlayerTokenPosition()
		{ 
			return _players[_currentPlayer].GetPosition();	
		}


		public int PutCurrentPlayerInPosition(int position)
		{
			 _players[_currentPlayer]._tokenPosition = position;
			return position;
		}

		public int GetPreviusPlayerTokenPosition()
		{
			int position = 0;
			if (_currentPlayer > 0)
			{
				 position = _players[_currentPlayer - 1].GetPosition();
			}
			else
			{
				position = _players[_players.Count - 1].GetPosition();
			}
			
			if (position > 0)
			{
				return position;
			}

			return 0;
		}

		public string GetPlayersName()
		{
			var playersName = string.Empty;
			foreach (var player in _players)
			{
				playersName += player.GetName()+ " ";
			}
			return playersName;
		}

		public int GetPreviusPlayerTokenNumber()
		{
			if (_currentPlayer == 0)
			{
				return _players.Count - 1;
			}

			return _currentPlayer -1;
		}


		public int Move(int steps)
		{
			return _players[_currentPlayer].Move(steps);
		}

	}
}

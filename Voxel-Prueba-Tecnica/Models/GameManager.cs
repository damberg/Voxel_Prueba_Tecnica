using Voxel_Prueba_Tecnica.Enums;

namespace Voxel_Prueba_Tecnica.Models
{
	public class GameManager
	{
		State _state { get; set; } = State.Stoped;
		
		public State StartGame(int nPlayers)
		{
			if (nPlayers > 1 && _state == State.Stoped)
			{
				_state = State.Started;
			}	    

			return this._state;
		}
		
		public State GetState()
		{
			return _state;
		}

		public State StatusAfterPlay(int newPosition)
		{
			if (newPosition == 100)
			{
				_state = State.Finished;
			}
			return _state;
		}
	}
}

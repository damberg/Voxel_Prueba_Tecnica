
namespace Voxel_Prueba_Tecnica.Models
{
	public class Player
	{
		public string _name { get; set; }
		public int _tokenPosition { get; set; } = 1;
		public Player(string name)
		{
			_name = name;
			_tokenPosition = 1;
		}

		public int Move(int diceResult)
		{
			var newPosition = _tokenPosition + diceResult;
			if (newPosition < 101 )
			{
				_tokenPosition = newPosition;
			}

			return _tokenPosition;
		}

		public int GetPosition()
		{
			return _tokenPosition;
		}

		public string GetName()
		{
			return _name;
		}

	}
}

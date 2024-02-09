using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
	public class Player
	{
		public String Name;
		public char Color;
		public List<Piece> PlayerPieces;

		public Player(String Name, char Color, List<Piece> pieces)
		{
			this.Name = Name;
			this.Color = Color;
			this.PlayerPieces = pieces;
		}
		public override string ToString()
		{
			return Name + "(" + Color + ")";
		}
	}
}

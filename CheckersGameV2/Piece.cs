using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
	public abstract class Piece
	{
		public Coordinates Coordinates;
		public char Color;
		public String Symbol;
		
		public Piece(Coordinates coordinates, char color)
		{
			Coordinates = coordinates;
			Color = color;
		}

		public Coordinates getPieceCoordinates() { return Coordinates; }

		public String getSymbol() { return Symbol; }

		



	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
	public class QueenPiece :Piece
	{
		public QueenPiece(Coordinates coordinates, char color) : base(coordinates, color) 
		{
			if (color == 'w') Symbol = "Q";
			else if (color == 'b') Symbol = "K";
		}
	}
}

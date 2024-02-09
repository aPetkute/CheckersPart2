using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
	public class BasicPiece :Piece
	{
		public BasicPiece(Coordinates coordinates, char color) :base(coordinates, color) 
		{
			if (color == 'w') Symbol = "O";
			else if (color == 'b') Symbol = "X";
		}



		
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
	public class QueenPieceFactory : PieceFactory
	{
		public override Piece CreatePiece(Coordinates coordinates, char color)
		{
			return new QueenPiece(coordinates, color);
		}
	}
}

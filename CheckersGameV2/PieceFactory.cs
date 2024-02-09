using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
	public abstract class PieceFactory
	{
		public abstract Piece CreatePiece(Coordinates coordinates, char color);
	}
}

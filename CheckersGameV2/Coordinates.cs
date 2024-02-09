using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckersGameV2
{
	public class Coordinates
	{
		public int Row;
		public int Col;

		public Coordinates(int row, int col)
		{
			this.Row = row;
			this.Col = col;
		}
		//public int getRow() { return row; }
		//public int getCol() { return col; }
		public void setRow(int row) { this.Row = row;}
		public void setCol(int col) {  this.Col = col;}

		public override string ToString()
		{
			return Row + "," + Col;
		}

	}
}

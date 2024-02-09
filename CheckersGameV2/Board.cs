using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
    public class Board
    {
        public Piece[,] pieces;
        public Board(List<Piece> player1pieces, List<Piece> player2pieces, int size)
        {
            pieces = new Piece[size, size];
            InitializePlayerPieces(player1pieces);
            InitializePlayerPieces(player2pieces);
        }
        private void InitializePlayerPieces(List<Piece> pieces)
        {
            int row, col;
            foreach (var item in pieces)
            {
                row = item.getPieceCoordinates().Row;
                col = item.getPieceCoordinates().Col;
                this.pieces[row, col] = item;
            }
        }

        public void UpdateBoard(Player player1, Player player2)
        {
            CleanBoard();
            foreach(var piece in player1.PlayerPieces)
            {
                pieces[piece.Coordinates.Row, piece.Coordinates.Col] = piece;
            }
            foreach(var piece in player2.PlayerPieces)
            {
                pieces[piece.Coordinates.Row, piece.Coordinates.Col] = piece;
            }

            Display();
        }

        private void CleanBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pieces[i, j] = null;
                }
            }
        }


        public void Display()
        {
            Console.Clear();

            Console.WriteLine("        * C H E C K E R S *\n");

            Console.WriteLine("    A   B   C   D   E   F   G   H");
            Console.WriteLine("  |---+---+---+---+---+---+---+---|");

            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + 1 + " |");
                for (int j = 0; j < 8; j++)
                {
                    if (pieces[i, j] != null)
                    {
                        Console.Write(" " + pieces[i, j].getSymbol() + " |");
                    }
                    else
                    {
                        Console.Write("   |");
                    }

                }
                Console.Write("\n");
                Console.WriteLine("  |---+---+---+---+---+---+---+---|");
            }
        }
    }
}

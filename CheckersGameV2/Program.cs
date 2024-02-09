using CheckersGameV2;
using System;

class Program
{
    static void Main(string[] args)
    {

		List<Piece> WhitePieces = new List<Piece>();
        List<Piece> BlackPieces = new List<Piece>();

        WhitePieces = Rules.NewListOfInitialUpperPieces('w');
        BlackPieces = Rules.NewListOfInitialLowerPieces('b');


        Player Player1 = new Player("Player 1", 'w', WhitePieces);
        Player PLayer2 = new Player("Player 2", 'b', BlackPieces);


        Board Board = new Board(WhitePieces, BlackPieces, 8);
        PieceFactory basicPieceFactory = new BasicPieceFactory();
        Rules rules = new Rules(8, basicPieceFactory);

        Game Game = new Game(Player1, PLayer2, Board, rules);

        Board.Display();

        Game.Play();
    }
}

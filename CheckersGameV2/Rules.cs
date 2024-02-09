using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
    public class Rules
    {
        private int size;
		public PieceFactory pFactory;

		public Rules(int size, PieceFactory pieceFactory)
		{
			this.size = size;
			this.pFactory = pieceFactory;
		}
		public bool CheckMove(Player player, List<Coordinates> playerMove, Board board)
        {
            if (!IsInBoard(playerMove))
            {
                Console.WriteLine("Selected piece is out of board bound or move is out of board bounds");
                return false;
            }
            var selectedPiece = SelectedPieceExist(player, playerMove.FirstOrDefault());
            if (selectedPiece == null)
            {
                Console.WriteLine("Incorect piece position or selected piece does not belong to the player");
                return false;
            }
            if (!IsInRange(playerMove.Last(), selectedPiece))
            {
                Console.WriteLine("Move is out of piece range");
                return false;
            }
            if (!MoveIsPossibe(playerMove.Last(), selectedPiece, board))
            {
                Console.WriteLine("Invalid move");
                return false;
            }
            return true;
        }

        public Piece SelectedPieceExist(Player player, Coordinates piece)
        {
            return player.PlayerPieces.FirstOrDefault(x => x.Coordinates.Col == piece.Col && x.Coordinates.Row == piece.Row);
        }

        public bool MoveIsPossibe(Coordinates playerMove, Piece selectedPiece, Board board)
        {
            if (selectedPiece.GetType() == typeof(BasicPiece))
            {
                return board.pieces[playerMove.Row, playerMove.Col] == null;
            }
            return true;
        }

        public bool IsInBoard(List<Coordinates> move)
        {
            foreach (var coordinates in move)
            {
                if (coordinates.Row > (size - 1) || coordinates.Row < 0 ||
                    coordinates.Col > (size - 1) || coordinates.Col < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

		public bool IsInRange(Coordinates move, Piece selectedPiece)
		{
			if (selectedPiece.GetType() == typeof(BasicPiece))
			{
				List<Coordinates> possibleMoves = new List<Coordinates>();
				for (int i = 1; i < 3; i++)
				{
					possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row - i, selectedPiece.Coordinates.Col - i));
					possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row - i, selectedPiece.Coordinates.Col + i));
					possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row + i, selectedPiece.Coordinates.Col - i));
					possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row + i, selectedPiece.Coordinates.Col + i));
				}

				return possibleMoves.Any(x => x.Row == move.Row && x.Col == move.Col);
			}
			if (selectedPiece.GetType() == typeof(QueenPiece))
			{
				var possibleMoves = GetQueenTrajectory(selectedPiece);

				return possibleMoves.Any(x => x.Row == move.Row && x.Col == move.Col);
			}

			return true;
		}

		public void Move(List<Coordinates> playerMove, Player currentPlayer, Player opponent)
		{
			var selectedPiece = currentPlayer.PlayerPieces.FirstOrDefault(x => x.Coordinates.Row == playerMove[0].Row && x.Coordinates.Col == playerMove[0].Col);
			if (WasAttack(playerMove))
			{
				var capturedPiece = CheckIfAttackWasWalid(playerMove, opponent, selectedPiece);
				if (capturedPiece != null)
					opponent.PlayerPieces.Remove(capturedPiece);
			}
			selectedPiece.Coordinates = playerMove[1];
			CheckForQueen(currentPlayer, selectedPiece);
		}

		public Piece CheckIfAttackWasWalid(List<Coordinates> playerMove, Player opponent, Piece selectedPiece)
		{
			if (selectedPiece.GetType() == typeof(BasicPiece))
			{
				return opponent.PlayerPieces.FirstOrDefault(x => x.Coordinates.Row == ((playerMove[0].Row + playerMove[1].Row) / 2) && x.Coordinates.Col == ((playerMove[0].Col + playerMove[1].Col) / 2));
			}
			else
			{
				var queenTrajectory = GetQueenTrajectory(selectedPiece);

				foreach (var trajectory in queenTrajectory)
				{
					return opponent.PlayerPieces.FirstOrDefault(x => x.Coordinates.Row == trajectory.Row && x.Coordinates.Col == trajectory.Col);
				}
				return null;
			}
		}

		public bool WasAttack(List<Coordinates> playerMove)
        {
            return playerMove[0].Row - playerMove[1].Row < -1 || playerMove[0].Row - playerMove[1].Row > 1;
        }
		public static List<Piece> NewListOfInitialUpperPieces(char color)
		{
            List<Piece> pieces = new List<Piece>();
			pieces.Add(new BasicPiece(new Coordinates(0, 0), color));
			pieces.Add(new BasicPiece(new Coordinates(0, 2), color));
			pieces.Add(new BasicPiece(new Coordinates(0, 4), color));
			pieces.Add(new BasicPiece(new Coordinates(0, 6), color));
			pieces.Add(new BasicPiece(new Coordinates(1, 1), color));
			pieces.Add(new BasicPiece(new Coordinates(1, 3), color));
			pieces.Add(new BasicPiece(new Coordinates(1, 5), color));
			pieces.Add(new BasicPiece(new Coordinates(1, 7), color));
			pieces.Add(new BasicPiece(new Coordinates(2, 0), color));
			pieces.Add(new BasicPiece(new Coordinates(2, 2), color));
			pieces.Add(new BasicPiece(new Coordinates(2, 4), color));
			pieces.Add(new BasicPiece(new Coordinates(2, 6), color));

			return pieces;
		}
		public static List<Piece> NewListOfInitialLowerPieces(char color)
		{
			List<Piece> pieces = new List<Piece>();
			pieces.Add(new BasicPiece(new Coordinates(5, 1), color));
			pieces.Add(new BasicPiece(new Coordinates(5, 3), color));
			pieces.Add(new BasicPiece(new Coordinates(5, 5), color));
			pieces.Add(new BasicPiece(new Coordinates(5, 7), color));
			pieces.Add(new BasicPiece(new Coordinates(6, 0), color));
			pieces.Add(new BasicPiece(new Coordinates(6, 2), color));
			pieces.Add(new BasicPiece(new Coordinates(6, 4), color));
			pieces.Add(new BasicPiece(new Coordinates(6, 6), color));
			pieces.Add(new BasicPiece(new Coordinates(7, 1), color));
			pieces.Add(new BasicPiece(new Coordinates(7, 3), color));
			pieces.Add(new BasicPiece(new Coordinates(7, 5), color));
			pieces.Add(new BasicPiece(new Coordinates(7, 7), color));

			return pieces;
		}
		public void CheckForQueen(Player currentPlayer, Piece selectedPiece)
		{
			if (currentPlayer.Color == 'w')
			{
				if (selectedPiece.Coordinates.Row == 7)
				{
					QueenPiece queen = new(selectedPiece.Coordinates, selectedPiece.Color);
					currentPlayer.PlayerPieces.Remove(selectedPiece);
					currentPlayer.PlayerPieces.Add(queen);
				}
			}
			else
			{
				if (selectedPiece.Coordinates.Row == 0)
				{
					QueenPiece queen = new(selectedPiece.Coordinates, selectedPiece.Color);
					currentPlayer.PlayerPieces.Remove(selectedPiece);
					currentPlayer.PlayerPieces.Add(queen);
				}
			}
		}
		public List<Coordinates> GetQueenTrajectory(Piece selectedPiece)
		{
			List<Coordinates> possibleMoves = new List<Coordinates>();

			for (int i = 1; i < 8; i++)
			{
				possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row - i, selectedPiece.Coordinates.Col - i));
				possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row - i, selectedPiece.Coordinates.Col + i));
				possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row + i, selectedPiece.Coordinates.Col - i));
				possibleMoves.Add(new Coordinates(selectedPiece.Coordinates.Row + i, selectedPiece.Coordinates.Col + i));
			}
			var invalidMoves = possibleMoves.Where(x => x.Col > 7 || x.Col < 0 || x.Row > 7 || x.Row < 0).ToList();

			foreach (var invalidMove in invalidMoves)
			{
				possibleMoves.Remove(invalidMove);
			}
			return possibleMoves;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGameV2
{
    public class Game
    {
        protected Player currentPlayer;
        protected Player currentOpponent;
        protected Player? winner;
        protected Board board;
        protected List<Coordinates> playerMove;
        private Rules rules;

        public Game(Player player1, Player player2, Board board, Rules rules)
        {
            currentPlayer = player1;
            currentOpponent = player2;
            winner = null;
            this.board = board;
            this.rules = rules;
            playerMove = new List<Coordinates>();
        }
        
        public void Play()
        {
            while (winner == null)
            {
                DisplayStartTurn();
                playerMove = GetInput();
                while (!rules.CheckMove(currentPlayer, playerMove, board))
                {
                    DisplayStartTurn();
                    playerMove = GetInput();
                };

                rules.Move(playerMove, currentPlayer, currentOpponent);

                board.UpdateBoard(currentPlayer, currentOpponent);

                if (!currentOpponent.PlayerPieces.Any()) winner = currentPlayer;

                SwitchTurn();
                //Board.CheckMoveValidity();
                //make move


            }

        }

        public void SwitchTurn()
        {
            Player temp = currentPlayer;
            currentPlayer = currentOpponent;
            currentOpponent = temp;
        }
        private void DisplayStartTurn()
        {
            Console.WriteLine("Player " + currentPlayer.ToString() + " 's turn!- enter 2 positions (ex. 3C 4D):");
        }

        public List<Coordinates> GetInput()
        {
            String input;
            List<Coordinates> TwoCoordinates = new List<Coordinates>();
            input = Console.ReadLine();
            while (input.Length < 5)
            {
                Console.WriteLine("Invalid input");
                input = Console.ReadLine();
            }
            input = input.ToLower();

            input = input.Replace(" ", string.Empty);

            Coordinates Location = new Coordinates((((int)input[0]) - 48 - 1), (((int)input[1]) - 96 - 1));
            Coordinates Destination = new Coordinates((((int)input[2]) - 48 - 1), (((int)input[3]) - 96 - 1));

            TwoCoordinates.Add(Location);
            TwoCoordinates.Add(Destination);


            return TwoCoordinates;
        }
    }
}

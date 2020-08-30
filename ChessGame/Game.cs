using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class Game
    {
        private readonly IBoard board;
        private Player whitePlayer;
        private Player blackPlayer;
        public Player currentPlayer;
        public Game(bool withPieces = true)
        {
            board = withPieces ? new Board() : new Board(false);

            whitePlayer = new Player(board, PieceColor.White);
            blackPlayer = new Player(board, PieceColor.Black);
            currentPlayer = whitePlayer;
        }

        public Player WhitePlayer { get => whitePlayer; }
        public Player BlackPlayer { get => blackPlayer; }

        public IBoard Board => board;

        public void Play(List<string> listOfMoves)
        {
            foreach (var m in listOfMoves)
            {
                var moveAN = MoveNotationConverter.ParseMoveNotation(m);

                NextTurn(currentPlayer, moveAN);


            }
        }

        private void NextTurn(Player player, IMoveAN moveAN)
        {
            var targetCellFromMoveAN = board.GetCell(moveAN.Coordinate.Row, moveAN.Coordinate.Column);
            var allValidMovesOfPieces = player.GenerateAllLegalMoves();
            foreach (var move in allValidMovesOfPieces)
            {
                move.MoveAN = moveAN;
             
                if (move.TargetPosition == targetCellFromMoveAN)
                {
                    player.MakeMove(move);
                }

            }
      
            currentPlayer = currentPlayer == whitePlayer ? blackPlayer : whitePlayer;

        }
    }
}

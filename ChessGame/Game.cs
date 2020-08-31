using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class Game
    {
        private readonly IBoard board;
        public Player currentPlayer;
        public Game(bool withPieces = true)
        {
            board = withPieces ? new Board() : new Board(false);

            WhitePlayer = new Player(board, PieceColor.White);
            BlackPlayer = new Player(board, PieceColor.Black);
            currentPlayer = WhitePlayer;
        }

        public Player WhitePlayer { get; }
        public Player BlackPlayer { get; }

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
            var allValidMovesOfPieces = player.GenerateAllLegalMoves();
            if (moveAN.Coordinate != null) 
            {
                var targetCellFromMoveAN = board.GetCell(moveAN.Coordinate.Row, moveAN.Coordinate.Column);
                var findAllMovesCanHitTargetPosition = allValidMovesOfPieces.Where(m => m.TargetPosition == targetCellFromMoveAN);
                IMove findCorrectMove = null;
                if (moveAN.File != -1)
                {
                      findCorrectMove = findAllMovesCanHitTargetPosition.Where(p => p.InitialPosition.Column == moveAN.File
                                                                     && p.InitialPosition.Piece.GetType() == moveAN.PieceType).Single();
                }
                else
                {
                    findCorrectMove = findAllMovesCanHitTargetPosition.Where(p =>  p.InitialPosition.Piece.GetType() == moveAN.PieceType).Single();
                }

                if (findCorrectMove == null)
                {
                    throw new InvalidOperationException("Invalid move");
                }
                findCorrectMove.MoveAN = moveAN;
                player.MakeMove(findCorrectMove);


            }
            if (moveAN.IsKingCastling)
            {

            }
         
      
            currentPlayer = currentPlayer == WhitePlayer ? BlackPlayer : WhitePlayer;

        }
    }
}

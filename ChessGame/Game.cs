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
        public Game()
        {
            board = new Board();

            WhitePlayer = new Player(board, PieceColor.White);
            BlackPlayer = new Player(board, PieceColor.Black);
            currentPlayer = WhitePlayer;
        }

        public Player WhitePlayer { get; }
        public Player BlackPlayer { get; }

        public IBoard Board => board;

        public void Play(List<string> listOfMoves)
        {
            ListMoveExceptions(listOfMoves);
            foreach (var m in listOfMoves)
            {
                MoveExceptions(m);
                var moveAN = MoveNotationConverter.ParseMoveNotation(m);
                NextTurn(currentPlayer, moveAN);

            }
        }

        private void NextTurn(Player player, IMoveAN moveAN)
        {
            var validMoves = player.GenerateAllLegalMoves();
            if (moveAN.Coordinate != null) 
            {
                var targetCell = board.GetCell(moveAN.Coordinate.Row, moveAN.Coordinate.Column);
       
                var movesHitTargetCell = validMoves.Where(m => m.TargetPosition == targetCell
                                && m.InitialPosition.Piece.GetType() == moveAN.PieceType);
    
                ListMoveExceptions<Move>(movesHitTargetCell);

                IMove findCorrectMove = moveAN.File != -1
                    ? movesHitTargetCell.Where(p => p.InitialPosition.Column == moveAN.File).Single()
                    : movesHitTargetCell.Single();
                //must move this in Play??
                if (findCorrectMove == null)
                {
                    throw new InvalidOperationException("Invalid move");
                }
                findCorrectMove.MoveAN = moveAN;
                player.MakeMove(findCorrectMove);
            }
            if (moveAN.IsKingCastling || moveAN.IsQueenCastling)
            {
                var isKingSide = moveAN.IsKingCastling ? true : false;
                var color = player == WhitePlayer ? PieceColor.White : PieceColor.Black;
                board.Castling(color, isKingSide);
            }
           
            currentPlayer = currentPlayer == WhitePlayer ? BlackPlayer : WhitePlayer;
        }

        private void MoveExceptions(string move)
        {
            if (string.IsNullOrEmpty(move))
            {
                throw new InvalidOperationException("There is no move");
            }
        }

        private void ListMoveExceptions<T>(IEnumerable<T> moves)
        {
            if (moves == null || moves.Count() == 0 || !moves.Any())
            {
                throw new InvalidOperationException("There are no legal moves in the list");
            }
        }
    }
}

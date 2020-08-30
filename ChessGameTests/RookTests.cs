using ChessGame;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessGameTests
{
    public class RookTests
    {
        [Fact]
        public void GenerateLegalMoves()
        {

            Board board = new Board();
    
            var initialPosition = board.GetCell(6, 7);
            var targetPosition = board.GetCell(4, 7);

            var move = new Move(initialPosition, targetPosition, null);

            var player = new Player(board, PieceColor.White);

            player.MakeMove(move);



            //move rook
            var initialPositionRook = board.GetCell(7, 7);
            var targetPositionRook = board.GetCell(5, 7);

            var moveRook = new Move(initialPositionRook, targetPositionRook, null);
            player.MakeMove(moveRook);


            Rook rook = (Rook)targetPositionRook.Piece;
            var list = rook.GenerateLegalMoves();

            Assert.Equal(9, list.Count());
        }
    }
}

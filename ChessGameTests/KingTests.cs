using ChessGame;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessGameTests
{
    public class KingTests
    {
        [Fact]
        public void GenerateLegalMoves()
        {

            Board board = new Board();
            //pawn in front of king
            var initialPosition = board.GetCell(6, 4);
            var targetPosition = board.GetCell(5, 4);
       
            var move = new Move(initialPosition, targetPosition, null);

            var player = new Player(board, PieceColor.White);

            player.MakeMove(move);

            

            //move king
            var initialPositionKing = board.GetCell(7, 4);
            var targetPositionKing = board.GetCell(6, 4);
    
            var moveKing = new Move(initialPositionKing, targetPositionKing, null);
            player.MakeMove(moveKing);


            King king = (King)targetPositionKing.Piece;
            var list = king.GenerateLegalMoves();

            Assert.Equal(3, list.Count());
        }
    }

}

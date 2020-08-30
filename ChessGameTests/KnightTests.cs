using ChessGame;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessGameTests
{
    public class KnightTests
    {
        [Fact]
        public void GenerateLegalMoves()
        {

            Board board = new Board();

            var initialPosition = board.GetCell(7, 6);
            var targetPosition = board.GetCell(5, 5);
            var piece = initialPosition.Piece;

            var move = new Move(initialPosition, targetPosition, null);

            var player = new Player(board, PieceColor.White);
        
            player.MakeMove(move);


            Knight knight = (Knight)piece;
            var list = knight.GenerateLegalMoves();

            Assert.Equal(5, list.Count());
        }
    }
}

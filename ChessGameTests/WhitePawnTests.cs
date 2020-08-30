using ChessGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChessGameTests
{
    public class WhitePawnTests
    {
        [Fact]
        public void GenerateLegalMoves()
        {

            Board board = new Board();

            var initialPosition = board.GetCell(6, 2);
  
            var piece = initialPosition.Piece;

            WhitePawn wp = (WhitePawn)piece;
            var list = wp.GenerateLegalMoves();

            Assert.Equal(2, list.Count());
        }
    }
}

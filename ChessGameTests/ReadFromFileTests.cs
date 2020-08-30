using ChessGame;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace ChessGameTests
{
    public class ReadFromFileTests
    {
        [Fact]
        public void ReadFromFileShoudReturnListOfMoves()
        {
            var listOfMoves = ReadFromFile.ProcessFile("chess-moves.txt");

            string move1 = listOfMoves[0];
            string move2 = listOfMoves[1];
    

            Assert.Equal("Pe4", move1);
            Assert.Equal("Pe5", move2);
        }
        [Fact]
        public void CheckIfParseIsCorrect()
        {
            
            var move = MoveNotationConverter.ParseMoveNotation("Pa4Q");
         
            Assert.False(move.IsCheckMate);
            Assert.True(move.IsPromotion);
        }

    }
}

using ChessGame;
using ChessGame.Pieces;
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
        [Fact]
        public void CheckRegexForKingCastlingShouldReturnNewPiece()
        {
            var notation = "0-0";
    
            var move = MoveNotationConverter.ParseMoveNotation(notation);


            Assert.True(move.IsKingCastling);
            Assert.False(move.IsQueenCastling);
        }
        [Fact]
        public void CheckRegexForMovePawnToPromotionShouldReturnNewPiece()
        {
            var notation = "Pe8Q++";
            var move = MoveNotationConverter.ParseMoveNotation(notation);

            Assert.NotNull(move.Coordinate);
            Assert.True(move.IsPromotion);

            Assert.False(move.IsCheck);
            Assert.True(move.IsCheckMate);
        }

        [Fact]
        public void CheckRegexForMoveBishopShouldReturn()
        {
            var notation = "Be5+";
   
            var move = MoveNotationConverter.ParseMoveNotation(notation);

            Assert.NotNull(move.Coordinate);
            Assert.False(move.IsPromotion);

            Assert.True(move.IsCheck);
            Assert.False(move.IsCheckMate);
        }

        [Fact]
        public void CheckRegexForMoveBishopWithCaptureShouldReturn()
        {
            var notation = "Bxe5";
         
            var move = MoveNotationConverter.ParseMoveNotation(notation);

            Assert.NotNull(move.Coordinate);
            Assert.False(move.IsPromotion);

    
            Assert.False(move.IsCheck);
            Assert.False(move.IsCheckMate);

        }

    }
}

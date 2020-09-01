using ChessGame;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace ChessGameTests
{

    public class GameTests
    {
        [Fact]
        public void ListMovesEmptyShouldThrowException()
        {
            var listOfMoves = new List<string>() { };
            var game = new Game();
            Assert.Throws<InvalidOperationException>(() => game.Play(listOfMoves));
        }

        [Fact]
        public void ListMovesNullShouldThrowException()
        {
            var game = new Game();
            Assert.Throws<InvalidOperationException>(() => game.Play(null));
        }

        [Fact]
        public void ListMovesInvalidMoveShouldThrowException()
        {
            var game = new Game();
            var listOfMoves = new List<string>()
            {
                "Wk4"
            };
            Assert.Throws<InvalidOperationException>(() => game.Play(listOfMoves));
        }

        [Fact]
        public void ListMovesWithEmptyMoveShouldThrowException()
        {
            var game = new Game();
            var listOfMoves = new List<string>()
            {
                "Pe4", ""
            };
            Assert.Throws<InvalidOperationException>(() => game.Play(listOfMoves));
        }


        //de vazut cum sa trimit ex ca si parametrii
        [Fact]
        public void PlayPartialGameWithInvalidMoveShouldThrowError()
        {
            //Bf4 should throw ex
            var listOfMoves = new List<string>()
            {
                "Pe4","pe5","Bf4"
            };

            var game = new Game();
            game.Play(listOfMoves);

            Assert.Throws<InvalidOperationException>(() => game.Play(listOfMoves));
        }

    }
}

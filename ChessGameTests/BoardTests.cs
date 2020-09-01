using ChessGame;
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChessGameTests
{
    public class BoardTests
    {
        [Fact]
        public void CheckRookIsPlacedCorrectlyOnBoard()
        {

            Board board = new Board();

            var rook = board.GetCell(0, 0).Piece;

            Assert.IsType<Rook>(rook);
            Assert.Equal(PieceColor.Black, rook.Color);
        }

        [Fact]
        public void CheckIFPiecesArePlacesInArmy()
        {

            Board board = new Board();

            var army = board.GetArmy(PieceColor.White);
            var army2 = board.GetArmy(PieceColor.Black);
            
            Assert.Equal(16, army.AlivePieces.Count);
            Assert.Equal(16, army2.AlivePieces.Count);
            Assert.Equal(0, army.DeadPieces.Count);
            Assert.Equal(0, army2.DeadPieces.Count);
        }

        [Fact]
        public void CheckIFPieceMakesMove()
        {

            Board board = new Board();

            var initialPosition = board.GetCell(6, 4);
            var targetPosition = board.GetCell(5, 4);
            var piece = board.GetCell(6, 4).Piece;

            var move = new Move(initialPosition, targetPosition, piece);

            var player = new Player(board, PieceColor.White);
            player.MakeMove(move);

            
            Assert.Null(initialPosition.Piece);

            Assert.Equal(piece, targetPosition.Piece);

        }

        [Fact]
        public void CoordonateXOutOfBoundShouldReturnNull()
        {
            var board = new Board();
    
            Assert.Null(board.GetCell(8, 0));
        }

        [Fact]
        public void CoordonatYsOutOfBoundShouldReturnNull()
        {
            var board = new Board();

            Assert.Null(board.GetCell(8, 8));
        }

        [Fact]
        public void CheckWhitePawnForPromotion()
        {
          
            var game = new Game();
            var whiteArmy = game.Board.GetArmy(PieceColor.White);
            var blackArmy = game.Board.GetArmy(PieceColor.Black);
            blackArmy.AlivePieces.Clear();

            //to do make tests...

            var listOfMoves = new List<string>()
                {
                    "0-0-0"
                    // "Bdb8","0-0","Pb8Q"
                };
   
            game.Play(listOfMoves);
            var army = game.Board.GetArmy(PieceColor.White);
            var quuen = army.AlivePieces.Where(p => p is Queen).Single();

            Assert.IsType<Queen>(quuen);
        }


        [Fact]
        public void PlayGameWithPawnsAndQueenMovement()
        {
            var listOfMoves = new List<string>()
            {
                "Pd4", "pe5", "Pdxe5", "pf5","Qd5", "Qh4", "Qxd7+", 
                 "Bxd7",
                "Pe6","Kd8","Pe7+","Kc8","Pe8Q"
            };

            var game = new Game();
            game.Play(listOfMoves);

            var whiteArmy = game.Board.GetArmy(PieceColor.White);
            var blackArmy = game.Board.GetArmy(PieceColor.Black);
            Assert.Equal(2, whiteArmy.DeadPieces.Count);
            Assert.Equal(15, whiteArmy.AlivePieces.Count);

            Assert.Equal(2, blackArmy.DeadPieces.Count);
            Assert.Equal(14, blackArmy.AlivePieces.Count);
        }

        [Fact]
        public void PlayPartialGameWithCastlingAndCaptures()
        {
            var listOfMoves = new List<string>()
            {
                "Pe4","pe5","Bc4","pc5","Nf3","Qf6","0-0",
                "Nc6", "Nc3","pd5","Bxd5","Bg4","Bxc6+","Ne7"
            };

            var game = new Game();
            game.Play(listOfMoves);

            var whiteArmy = game.Board.GetArmy(PieceColor.White);
            var blackArmy = game.Board.GetArmy(PieceColor.Black);
            Assert.Equal(0, whiteArmy.DeadPieces.Count);
            Assert.Equal(16, whiteArmy.AlivePieces.Count);

            Assert.Equal(2, blackArmy.DeadPieces.Count);
            Assert.Equal(14, blackArmy.AlivePieces.Count);
        }


    }
}

using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class Move : IMove
    {
        public Move(Cell initialPosition, Cell targetPosition, Piece movingPiece)
        {
            InitialPosition = initialPosition;
            TargetPosition = targetPosition;
            MovingPiece = movingPiece;

        }

        public Cell InitialPosition { get; set; }

        public Piece MovingPiece { get; set; }

        public Cell TargetPosition { get; set; } 
        public IMoveAN MoveAN { get; set; }

        public Piece CreatePiece(char pieceUppercase, PieceColor pieceColor, Cell targetCell)
        {
            string piecesNameInitials = "RBQN";
            var charExists = piecesNameInitials.Contains(pieceUppercase);
            if (!charExists)
            {
                throw new InvalidOperationException("Invalid promotion!");
            }

            if (pieceUppercase == 'R')
            {
                return new Rook(targetCell, pieceColor);
            }
            if (pieceUppercase == 'Q')
            {
                return new Queen(targetCell, pieceColor);
            }
            if (pieceUppercase == 'B')
            {
                return new Bishop(targetCell, pieceColor);
            }
            if (pieceUppercase == 'N')
            {
                return new Knight(targetCell, pieceColor);
            }

            return null;
        }
    }
}

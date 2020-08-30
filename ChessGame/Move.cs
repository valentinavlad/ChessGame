using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class Move : IMove
    {
        IMoveAN moveAN;
        public Move(Cell initialPosition, Cell targetPosition, Piece movingPiece)
        {
            InitialPosition = initialPosition;
            TargetPosition = targetPosition;
            MovingPiece = movingPiece;

        }

        public Cell InitialPosition { get; set; }

        public Piece MovingPiece { get; set; }

        public Cell TargetPosition { get; set; }
        public IMoveAN MoveAN { get => moveAN; set => moveAN = value; }
    }
}

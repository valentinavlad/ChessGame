using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Cell cell, PieceColor color) : base(cell, color)
        {
        }

        public override IEnumerable<Cell> GenerateLegalMoves()
        {
            var validMoves = new List<Cell>();
            validMoves.AddRange(GenerateLiniarMoves(-1, 1));
            validMoves.AddRange(GenerateLiniarMoves(1, -1));
            validMoves.AddRange(GenerateLiniarMoves(-1, -1));
            validMoves.AddRange(GenerateLiniarMoves(1, 1));
            return validMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "B" : "_B";
        }
    }
}

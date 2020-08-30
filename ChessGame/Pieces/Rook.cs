using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Pieces
{
    public class Rook : Piece
    {
        public Rook(Cell cell, PieceColor color) : base(cell, color)
        {
        }

        public override IEnumerable<Cell> GenerateLegalMoves()
        {
            var validMoves = new List<Cell>();
            validMoves.AddRange(GenerateLiniarMoves(-1, 0));
            validMoves.AddRange(GenerateLiniarMoves(1, 0));
            validMoves.AddRange(GenerateLiniarMoves(0, 1));
            validMoves.AddRange(GenerateLiniarMoves(0, -1));
            return validMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "R" : "_R";
        }
    }
}

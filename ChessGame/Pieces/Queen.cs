using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Pieces
{
    public class Queen : Piece
    {
        public Queen(Cell cell, PieceColor color) : base(cell, color)
        {
        }

        public override IEnumerable<Cell> GenerateLegalMoves()
        {
            var validMoves = new List<Cell>();
            //rook moves
            validMoves.AddRange(GenerateLiniarMoves(-1, 0));
            validMoves.AddRange(GenerateLiniarMoves(1, 0));
            validMoves.AddRange(GenerateLiniarMoves(0, 1));
            validMoves.AddRange(GenerateLiniarMoves(0, -1));
            //bihop movez
            validMoves.AddRange(GenerateLiniarMoves(-1, 1));
            validMoves.AddRange(GenerateLiniarMoves(1, -1));
            validMoves.AddRange(GenerateLiniarMoves(-1, -1));
            validMoves.AddRange(GenerateLiniarMoves(1, 1));
            return validMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "Q" : "_Q";
        }
    }
}

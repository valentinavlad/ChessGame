using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Pieces
{
    public class King : Piece
    {
        public King(Cell cell, PieceColor color) : base(cell, color)
        {
        }

        public override IEnumerable<Cell> GenerateLegalMoves()
        {
            var validMoves = new List<Cell>();
            for (int row = -1; row <= 1; row++)
            {
                for (int col = -1; col <= 1; col++)
                {
                    Cell targetCell = Cell.GetAdiacetCell(row, col);
                    CheckCell(validMoves, targetCell);
                }
            }

            return validMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "K" : "_K";
        }
    }
}

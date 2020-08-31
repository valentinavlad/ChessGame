using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public void KingCastling()
        {
            if (!IsMoved)
            {
                var t = GenerateLiniarMoves2(0, 1);
                //Cell targetCell =
            }
        }
        protected bool GenerateLiniarMoves2(int row, int column)
        {           
            Cell targetCell = Cell.GetAdiacetCell(row, column);
            var rook = targetCell.Piece as Rook;
            while (targetCell.Piece == rook)
            {
                if (targetCell.Piece != null)
                {
                    return false;
                }
          
                targetCell = targetCell.GetAdiacetCell(row, column);
            }
            return true;
        }
        public override string ToString()
        {
            return Color == PieceColor.White ? "K" : "_K";
        }
    }
}

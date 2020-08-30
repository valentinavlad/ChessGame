using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Pieces
{
    public class Knight : Piece
    {
        public Knight(Cell cell, PieceColor color) : base(cell, color)
        {
        }

        public override IEnumerable<Cell> GenerateLegalMoves()
        {
            var validMoves = new List<Cell>();
            var targetCell = Cell.GetAdiacetCell(1, 2);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(-1, 2);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(1, -2);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(-1, 2);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(2, 1);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(-2, 1);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(2, -1);
            CheckCell(validMoves, targetCell);
            targetCell = Cell.GetAdiacetCell(-2, -1);
            CheckCell(validMoves, targetCell);
            return validMoves;
        }

        public override string ToString()
        {
            return Color == PieceColor.White ? "N" : "_N";
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class BlackPawn : Piece
    {
        public BlackPawn(Cell cell, PieceColor color) : base(cell, color)
        {
        }

        public override IEnumerable<Cell> GenerateLegalMoves()
        {
            var validMoves = new List<Cell>();
            Cell targetCell = Cell.GetAdiacetCell(1, 0);
            //move directlly
            if (targetCell != null && targetCell.Piece == null)
            {
                if (targetCell.Row == 7)
                {
                    IsPromoted = true;
                }
                validMoves.Add(targetCell);
                targetCell = Cell.GetAdiacetCell(2, 0);
                if (Cell.Row == 1 && targetCell.Piece == null)
                {
                    validMoves.Add(targetCell);

                }

            }

            targetCell = Cell.GetAdiacetCell(1, 1);
            if (targetCell != null && targetCell.Piece != null && targetCell.Piece.Color != Color)
            {
                validMoves.Add(targetCell);
            }
            targetCell = Cell.GetAdiacetCell(1, -1);
            if (targetCell != null && targetCell.Piece != null && targetCell.Piece.Color != Color)
            {
                validMoves.Add(targetCell);
            }

            return validMoves;
        }

        public override string ToString()
        {
            return "_P";
        }
    }
}

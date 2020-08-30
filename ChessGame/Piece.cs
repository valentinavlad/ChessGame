using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace ChessGame
{
    public enum PromoteOptions
    {
        Queen = 0, Rook = 1, Bishop = 2, Knight = 3
    }
    public abstract class Piece
    {
        protected Piece(Cell cell, PieceColor color)
        {
            Cell = cell;
            Cell.Piece = this;
            Color = color;
        }

        public bool IsPromoted { get; set; } = false;
        public Cell Cell { get; set; }
        public PieceColor Color { get; set; }

        public abstract IEnumerable<Cell> GenerateLegalMoves();
       
        protected void CheckCell(List<Cell> validMoves, Cell targetCell)
        {
            if (targetCell != null && (targetCell.Piece == null || targetCell.Piece.Color != Color))
            {
                validMoves.Add(targetCell);
            }
        }

        protected IEnumerable<Cell> GenerateLiniarMoves(int row, int column)
        {
            var validMoves = new List<Cell>();
            Cell targetCell = Cell.GetAdiacetCell(row, column);
            while(targetCell != null)
            {
                if(targetCell.Piece == null)
                {
                    validMoves.Add(targetCell);
                }
                else if(targetCell.Piece.Color == Color)
                {
                    break;
                }
                else
                {
                    validMoves.Add(targetCell);
                    break;
                }
                targetCell = targetCell.GetAdiacetCell(row, column);
            }
            return validMoves;
        }
    }
}
﻿using ChessGame.Pieces;

namespace ChessGame
{
    public interface IBoard
    {
        IArmy GetArmy(PieceColor color);
        Cell GetCell(int row, int column);
        Piece CreatePiece(char pieceUppercase, PieceColor pieceColor, Cell targetCell);
    }
}
using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class Board : IBoard
    {
        private readonly int LENGTH = 8;
        private Cell[,] cells;

        public Board(bool withPieces = true)
        {
            cells = new Cell[LENGTH, LENGTH];
            InitializeBoard();
            if (withPieces)
            {
                AddWhitePieces();
                AddBlackPieces();
            }
            else
            {
                AddWhitePieces1();
            }
         
        }
 
        public IArmy BlackArmy { get; set; } = new Army();
        public IArmy WhiteArmy { get; set; } = new Army();

        public IArmy GetArmy(PieceColor color)
        {
            return color == PieceColor.White ? WhiteArmy : BlackArmy;
        }

        public Cell GetCell(int row, int column)
        {
            return (row >= 0 && row < LENGTH && column >= 0 && column <LENGTH) 
                ? cells[row, column]
                : null;
        }

      
        private void InitializeBoard()
        {
            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    cells[i, j] = new Cell(this, i, j);
                }
            }
     
        }
        private void AddWhitePieces1()
        {
            WhiteArmy.AddPiece(new WhitePawn(GetCell(1, 1), PieceColor.White));
            WhiteArmy.AddPiece(new Rook(GetCell(7, 7), PieceColor.White));
            WhiteArmy.AddPiece(new King(GetCell(7, 4), PieceColor.White));
            WhiteArmy.AddPiece(new Bishop(GetCell(2, 3), PieceColor.White));
            WhiteArmy.AddPiece(new Bishop(GetCell(1, 0), PieceColor.White));
        }

        private void AddWhitePieces()
        {
            for (int i = 0; i < LENGTH; i++)
            {
                WhiteArmy.AddPiece(new WhitePawn(GetCell(6, i), PieceColor.White));
            }
            WhiteArmy.AddPiece(new Rook(GetCell(7, 0), PieceColor.White));
            WhiteArmy.AddPiece(new Rook(GetCell(7, 7), PieceColor.White));
            WhiteArmy.AddPiece(new Knight(GetCell(7, 1), PieceColor.White));
            WhiteArmy.AddPiece(new Knight(GetCell(7, 6), PieceColor.White));
            WhiteArmy.AddPiece(new Bishop(GetCell(7, 2), PieceColor.White));
            WhiteArmy.AddPiece(new Bishop(GetCell(7, 5), PieceColor.White));
            WhiteArmy.AddPiece(new Queen(GetCell(7, 3), PieceColor.White));
            WhiteArmy.AddPiece(new King(GetCell(7, 4), PieceColor.White));

        }

        private void AddBlackPieces()
        {
            for (int i = 0; i < LENGTH; i++)
            {
                BlackArmy.AddPiece(new BlackPawn(GetCell(1, i), PieceColor.Black));
            }
            BlackArmy.AddPiece(new Rook(GetCell(0, 0), PieceColor.Black));
            BlackArmy.AddPiece(new Rook(GetCell(0, 7), PieceColor.Black));
            BlackArmy.AddPiece(new Knight(GetCell(0, 1), PieceColor.Black));
            BlackArmy.AddPiece(new Knight(GetCell(0, 6), PieceColor.Black));
            BlackArmy.AddPiece(new Bishop(GetCell(0, 2), PieceColor.Black));
            BlackArmy.AddPiece(new Bishop(GetCell(0, 5), PieceColor.Black));
            BlackArmy.AddPiece(new Queen(GetCell(0, 3), PieceColor.Black));
            BlackArmy.AddPiece(new King(GetCell(0, 4), PieceColor.Black));

        }
        public Piece CreatePiece(char pieceUppercase, PieceColor pieceColor, Cell targetCell)
        {
            string piecesNameInitials = "RBQN";
            var charExists = piecesNameInitials.Contains(pieceUppercase);
            if (!charExists)
            {
                throw new InvalidOperationException("Invalid promotion!");
            }

            if (pieceUppercase == 'R')
            {
                return new Rook(targetCell, pieceColor);
            }
            if (pieceUppercase == 'Q')
            {
                return new Queen(targetCell, pieceColor);
            }
            if (pieceUppercase == 'B')
            {
                return new Bishop(targetCell, pieceColor);
            }
            if (pieceUppercase == 'N')
            {
                return new Knight(targetCell, pieceColor);
            }

            return null;
        }


    }
}

using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class Player
    {
        private IBoard board;
        private PieceColor color;
       
        public Player(IBoard board, PieceColor color)
        {
            this.board = board;
            this.color = color;
        }

        public void MakeMove(IMove move)
        {    
            if(move.TargetPosition.Piece != null)
            {
                IArmy army = board.GetArmy(GetOpponent());
                army.CapturedPiece(move.TargetPosition.Piece);
            }
            Piece pieceWhoMoves = move.InitialPosition.Piece;
           
            pieceWhoMoves.Cell = move.TargetPosition;
            move.TargetPosition.Piece = pieceWhoMoves;
            move.InitialPosition.Piece = null;

            if (pieceWhoMoves is WhitePawn || pieceWhoMoves is BlackPawn)
            {
                PawnPromotion(move, pieceWhoMoves);
            }
        }
            //     //Castling to the right
            //if (to.Piece is King && to.X - from.X == 2)
            //{
            //    Move(GetCell(7, to.Y), GetCell(to.X - 1, to.Y), promoteOption); //Move the rook as well
            //}

    public IEnumerable<Move> GenerateAllLegalMoves()
        {
            var alivePieces = board.GetArmy(color).AlivePieces;
            var legalMoves = new List<Move>();

            foreach (var piece in alivePieces)
            {
                foreach (var targetCell in piece.GenerateLegalMoves())
                {
                    var move = new Move(piece.Cell, targetCell, targetCell.Piece);
                    legalMoves.Add(move);
                }
            }
            return legalMoves;
        }

        private void PawnPromotion(IMove move, Piece pieceWhoMoves)
        {
            Piece wp = null;
            if(pieceWhoMoves.Color == PieceColor.White)
            {
                wp = (WhitePawn)pieceWhoMoves;
            }
            if (pieceWhoMoves.Color == PieceColor.Black)
            {
                wp = (BlackPawn)pieceWhoMoves;
            }
            if (wp.IsPromoted)
            {
                IArmy army = board.GetArmy(color);
                army.CapturedPiece(wp);
                var piece = board.CreatePiece(move.MoveAN.PromovatedTo, color, move.TargetPosition);
                army.AlivePieces.Add(piece);
            }
        }
        private PieceColor GetOpponent()
        {
            return color == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }
    }
}

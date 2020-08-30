using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Pieces
{
    public class Army : IArmy
    {
        private IList<Piece> alivePieces;
        private IList<Piece> deadPieces;

        public Army()
        {
            alivePieces = new List<Piece>();
            deadPieces = new List<Piece>();
        }

        public IList<Piece> AlivePieces
        {
            get => alivePieces;
            set => alivePieces = value;
        }

        public IList<Piece> DeadPieces
        {
            get => deadPieces;
            set => deadPieces = value;
        }

        public void AddPiece(Piece piece)
        {
            alivePieces.Add(piece);
        }

        public void CapturedPiece(Piece piece)
        {
            alivePieces.Remove(piece);
            deadPieces.Add(piece);
        }
    }
}

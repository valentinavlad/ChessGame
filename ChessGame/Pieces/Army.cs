using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame.Pieces
{
    public class Army : IArmy
    {
        public Army()
        {
            AlivePieces = new List<Piece>();
            DeadPieces = new List<Piece>();
        }

        public IList<Piece> AlivePieces { get; set; }

        public IList<Piece> DeadPieces { get; set; }

        public void AddPiece(Piece piece)
        {
            AlivePieces.Add(piece);
        }
 
        public void CapturedPiece(Piece piece)
        {
            AlivePieces.Remove(piece);
            DeadPieces.Add(piece);
        }
    }
}

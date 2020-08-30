using System.Collections.Generic;

namespace ChessGame.Pieces
{
    public interface IArmy
    {
        IList<Piece> AlivePieces { get; set; }
        IList<Piece> DeadPieces { get; set; }

        void AddPiece(Piece piece);
        void CapturedPiece(Piece piece);
    }
}
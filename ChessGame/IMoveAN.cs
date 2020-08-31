using System;

namespace ChessGame
{
    public interface IMoveAN
    {
        Coordinate Coordinate { get; set; }
        int File { get; set; }
        bool IsKingCastling { get; set; }
        bool IsQueenCastling { get; set; }
        bool IsCheck { get; set; }
        bool IsCheckMate { get; set; }
        bool IsPromotion { get; set; }
        char PromovatedTo { get; set; }
        Type PieceType { get; set; }
        void GetPieceType(string moveAN);
    }
}
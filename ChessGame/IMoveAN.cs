using System;

namespace ChessGame
{
    public interface IMoveAN :IMoveANCastling
    {
        Coordinate Coordinate { get; set; }
        int File { get; set; }
        bool IsCheck { get; set; }
        bool IsCheckMate { get; set; }
        bool IsPromotion { get; set; }
        char PromovatedTo { get; set; }
        Type PieceType { get; set; }
        void GetPieceType(string moveAN);
    }
}
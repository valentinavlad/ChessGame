namespace ChessGame
{
    public interface IMoveANCastling
    {
        bool IsKingCastling { get; set; }
        bool IsQueenCastling { get; set; }
    }
}
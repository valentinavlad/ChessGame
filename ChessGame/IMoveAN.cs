namespace ChessGame
{
    public interface IMoveAN
    {
        Coordinate Coordinate { get; set; }
        int File { get; set; }
        bool IsCastling { get; set; }
        bool IsCheck { get; set; }
        bool IsCheckMate { get; set; }
        bool IsPromotion { get; set; }
        char PromovatedTo { get; set; }
    }
}
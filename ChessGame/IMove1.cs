namespace ChessGame
{
    public interface IMove1
    {
        Cell InitialPosition { get; set; }
        IMoveAN MoveAN { get; set; }
        Piece MovingPiece { get; set; }
        Cell TargetPosition { get; set; }
    }
}
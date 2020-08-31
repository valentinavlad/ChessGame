namespace ChessGame
{
    public interface IMove
    {
        IMoveAN MoveAN { get; set; }
        Cell InitialPosition { get; set; }
        Piece MovingPiece { get; set; }
        Cell TargetPosition { get; set; }
        Piece CreatePiece(char pieceUppercase, PieceColor pieceColor, Cell targetCell);
    }
}
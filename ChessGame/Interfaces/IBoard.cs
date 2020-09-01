using ChessGame.Pieces;

namespace ChessGame
{
    public interface IBoard
    {
        IArmy GetArmy(PieceColor color);
        Cell GetCell(int row, int column);
        void Castling(PieceColor color, bool isKingSide);
    }
}
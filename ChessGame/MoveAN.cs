using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class MoveAN : IMoveAN
    {
        public MoveAN()
        {

        }
        public Coordinate Coordinate { get; set; }
        public bool IsCheck { get; set; }
        public bool IsCheckMate { get; set; }
        public bool IsPromotion { get; set; }
        public int File { get; set; } = -1;

        public char PromovatedTo { get; set; }
        public bool IsKingCastling { get; set; }
        public bool IsQueenCastling { get; set; }
        public Type PieceType { get; set; }

        public void GetPieceType(string moveAN)
        {
            switch (moveAN.First())
            {
                case 'K':
                    PieceType = typeof(King);
                    break;
                case 'Q':
                    PieceType = typeof(Queen);
                    break;
                case 'R':
                    PieceType = typeof(Rook);
                    break;
                case 'B':
                    PieceType = typeof(Bishop);
                    break;
                case 'N':
                    PieceType = typeof(Knight);
                    break;
                case 'P':
                    PieceType = typeof(WhitePawn);
                    break;
                case 'p':
                    PieceType = typeof(BlackPawn);
                    break;
                default:
                   
                    break;
            }
        }
    }
}

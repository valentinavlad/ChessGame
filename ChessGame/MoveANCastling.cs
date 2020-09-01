using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    public class MoveANCastling : IMoveANCastling
    {
        public bool IsKingCastling { get; set; }
        public bool IsQueenCastling { get; set; }
    }
}

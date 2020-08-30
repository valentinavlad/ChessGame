using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public class MoveAN : IMoveAN
    {
        public Coordinate Coordinate { get; set; }

        public bool IsCastling { get; set; }
        public bool IsCheck { get; set; }
        public bool IsCheckMate { get; set; }
        public bool IsPromotion { get; set; }
        public int File { get; set; }

        public char PromovatedTo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public static class HandleExceptions
    {
        public static void MoveExceptions(string move)
        {
            if (string.IsNullOrEmpty(move))
            {
                throw new InvalidOperationException("There is no move");
            }
        }

        public static void MoveException<T>(T move)
        {
            if (move == null)
            {
                throw new InvalidOperationException("Invalid move");
            }
        }

        public static void ListMoveExceptions<T>(IEnumerable<T> moves)
        {
            if (moves == null || moves.Count() == 0 || !moves.Any())
            {
                throw new InvalidOperationException("There are no legal moves in the list");
            }
        }
    }
}

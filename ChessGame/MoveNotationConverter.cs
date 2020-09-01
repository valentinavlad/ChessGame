using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChessGame
{
    public static class MoveNotationConverter
    {
        public static IMoveAN ParseMoveNotation(string moveNotation)
        {
            var firstChar = moveNotation.First();
            string pattern = "";
            var isSpecialPiece = "BRKNQ".Contains(moveNotation.First());

            IMoveAN move = new MoveAN();
            if (moveNotation.StartsWith("0"))
            {
                InterpretRegexCastling(moveNotation, pattern, move);
            }
            else
            {
                pattern = isSpecialPiece
               ? @"^(?<pieceUppercase>[BRQKN])(?<file>[a-h]{0,1})(?<capture>[x]{0,1})(?<coordinates>[a-h][1-8])(?<checkOrCheckMate>[+]{0,2})$"
               : @"^(?<pieceUppercase>[Pp])(?<file>[a-h]{0,1})(?<capture>[x]{0,1})(?<coordinates>[a-h][1-8])(?<promotion>[BRQKN]{0,1})(?<checkOrCheckMate>[+]{0,2})$";
                Match match = Regex.Match(moveNotation, pattern);
                if (match.Success)
                {
                    move.Coordinate = MoveNotationCoordinatesConverter.ConvertChessCoordinatesToArrayIndexes(match.Groups["coordinates"].Value);
                    string checkOrCheckMate = match.Groups["checkOrCheckMate"].Value;

                    move.GetPieceType(match.Groups["pieceUppercase"].Value);
                    string file = match.Groups["file"].Value;
                    if (file != "")
                    {
                        move.File = MoveNotationCoordinatesConverter.ConvertChessCoordinateFileToArrayIndex(file);
                    }
                    if (match.Groups["promotion"].Value != "")
                    {
                        move.IsPromotion = match.Groups["promotion"].Value != "" ? true : false;
                        move.PromovatedTo = match.Groups["promotion"].Value.First();
                    }
                    if (checkOrCheckMate != "")
                    {
                        move.IsCheck = checkOrCheckMate.Length == 1 ? true : false;
                        move.IsCheckMate = checkOrCheckMate.Length == 2 ? true : false;
                    }
                }
                else
                {
                    throw new InvalidOperationException("This move doesn't respect Algebraic Notation Convention. It can't be interpreted");
                }
            }
          

            return move;
        }

        private static void InterpretRegexCastling(string moveNotation, string pattern, IMoveAN move)
        {
            pattern = @"^(?<castling>[0]([-][0]){1,2})$";
            Match match = Regex.Match(moveNotation, pattern);
            if (match.Success)
            {
                if (match.Groups["castling"].Value == "0-0")
                {
                    move.IsKingCastling = true;
                }
                if (match.Groups["castling"].Value == "0-0-0")
                {
                    move.IsQueenCastling = true;
                }
                
            }
        }
    }
}

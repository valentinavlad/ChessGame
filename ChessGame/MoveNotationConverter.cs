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
           
            IMoveAN move = new MoveAN();

          
            pattern = char.IsUpper(firstChar) && firstChar != 'P'
            ? @"^(?<pieceUppercase>[BRQKN])(?<file>[a-h]{0,1})(?<capture>[x]{0,1})(?<coordinates>[a-h][1-8])(?<checkOrCheckMate>[+]{0,2})$"
            : @"^(?<pieceUppercase>[P])(?<file>[a-h]{0,1})(?<capture>[x]{0,1})(?<coordinates>[a-h][1-8])(?<promotion>[BRQKN]{0,1})(?<checkOrCheckMate>[+]{0,2})$";
                

            Match match = Regex.Match(moveNotation, pattern);
            string file;

            if (match.Success)
            {
                string coordinatesFromMove = match.Groups["coordinates"].Value;
                move.Coordinate = MoveNotationCoordinatesConverter.ConvertChessCoordinatesToArrayIndexes(coordinatesFromMove);
                string checkOrCheckMate = match.Groups["checkOrCheckMate"].Value;
                string pieceUppercase = match.Groups["pieceUppercase"].Value != "" ? match.Groups["pieceUppercase"].Value : "P";
                char promotion = match.Groups["promotion"].Value.First();
                file = match.Groups["file"].Value;
                if (file != "")
                {
                    move.File = MoveNotationCoordinatesConverter.ConvertChessCoordinateFileToArrayIndex(file);
                }
                if (match.Groups["promotion"].Value != "")
                {
                    move.IsPromotion = match.Groups["promotion"].Value != "" ? true : false;
                    move.PromovatedTo = promotion;
                }
               
                if (checkOrCheckMate != "")
                {
                    move.IsCheck = checkOrCheckMate.Length == 1 ? true : false;
                    move.IsCheckMate = checkOrCheckMate.Length == 2 ? true : false;
                }
     
               

            }
            else
            {
                throw new InvalidOperationException("Invalid move!");
            }




            return move;
        }

    }
}

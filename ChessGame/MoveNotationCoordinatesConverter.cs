using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public static class MoveNotationCoordinatesConverter
    {
        public static Coordinate ConvertChessCoordinatesToArrayIndexes(string coordsAN)
        {
            Coordinate coordinate = new Coordinate();
            if (coordsAN.Length != 2)
            {
                throw new IndexOutOfRangeException("coordonates must be exactly 2");
            }
            coordinate.Row = ConvertChessCoordinateRankToArrayIndex(coordsAN);
            coordinate.Column = ConvertChessCoordinateFileToArrayIndex(coordsAN);

            return coordinate;
        }

        public static Coordinate ConvertChessCoordinatesToArrayIndexes(int column, int row)
        {
            return new Coordinate
            {
                Column = column,
                Row = row
            };
        }

        public static int ConvertChessCoordinateFileToArrayIndex(string coordsAN)
        {
            string files = "abcdefgh"; //refers to columns 

            var file = coordsAN.First();

            return files.IndexOf(file);
        }

        public static int ConvertChessCoordinateRankToArrayIndex(string coordsAN)
        {
            string ranks = "87654321"; //refers to rows 

            var rank = coordsAN.Last();

            return ranks.IndexOf(rank);
        }
    }
}

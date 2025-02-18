﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChessGame
{
    public static class ReadFromFile
    {
        public static List<string> ProcessFile(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ParseLinesToMoves().Where(p => p != "")
                .ToList();
        }

        private static IEnumerable<string> ParseLinesToMoves(this IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var columns = line.Split(",");

                yield return columns[0];
                yield return columns[1];
            }

        }
    }
}

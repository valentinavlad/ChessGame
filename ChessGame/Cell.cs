namespace ChessGame
{
    public class Cell
    {
        private readonly IBoard board;
        private  int row;
        private  int column;

        public Cell(IBoard board, int row, int column)
        {
            this.board = board;
            this.row = row;
            this.column = column;
        }
        public Piece Piece { get; set; }

    

        public int Column { get => column; set => column = value; }
        public int Row { get => row; set => row = value; }

        public Cell GetAdiacetCell(int row, int column)
        {
            return board.GetCell(this.row + row, this.column + column);
        }
        public  Cell GetCellAfterCoordinates(int row, int column)
        {
           return board.GetCell(row,column);
        }
    }
}
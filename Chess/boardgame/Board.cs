namespace boardgame
{
    class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            if (rows != 8 || columns != 8)
            {
                throw new BoardException("Error creating the board. The board must have 8 rows and 8 columns.\n");
            }

            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece GetPiece(int row, int column)
        {
            if (!PositionExists(row, column))
            {
                throw new BoardException("Position not exist on the board.\n");
            }

            return Pieces[row, column];
        }

        public Piece GetPiece(Position position)
        {
            if (!PositionExists(position.Row, position.Column))
            {
                throw new BoardException("Position not exist on the board.\n");
            }

            return Pieces[position.Row, position.Column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (ThereIsAPiece(position))
            {
                throw new BoardException("There is a piece in that position " + position + "\n");
            }

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        private bool PositionExists(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool PositionExists(Position position)
        {
            return PositionExists(position.Row, position.Column);               
        }

        public bool ThereIsAPiece(Position position)
        {
            if (!PositionExists(position))
            {
                throw new BoardException("Position not exist on the board.\n");
            }  

            return GetPiece(position) != null;
           
        }

        public Piece RemovePiece(Position position)
        {
            if (!PositionExists(position))
            {
                throw new BoardException("Position not exist on the board.\n");
            }
            if (GetPiece(position) == null)
            {
                return null;
            }

            Piece removedPiece = GetPiece(position);
            removedPiece.Position = null;
            Pieces[position.Row, position.Column] = null;
            return removedPiece;
        }
    }
}

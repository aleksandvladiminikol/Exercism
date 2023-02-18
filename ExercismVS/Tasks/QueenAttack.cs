    using System;
    using System.ComponentModel.DataAnnotations;

    public class Queen
    {
        public Queen(int row, int column)
        {
            if (row < 0 || row > 7 || column < 0 || column > 7)
            {
                throw new ArgumentOutOfRangeException("Row and column must be between 0 and 7");
            }

            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }


    public static class QueenAttack
    {
        public static bool CanAttack(Queen white, Queen black) 
            => (white.Column == black.Column || 
                white.Row == black.Row || 
                Math.Abs(white.Column - black.Column) == Math.Abs(white.Row - black.Row));

        public static Queen Create(int row, int column) => new Queen(row, column);
    }
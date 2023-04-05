using System;
using System.Linq;
public class Matrix
{
    private readonly int[][] _matrix;
    public Matrix(string input)
    {
        _matrix = input.Split("\n").Select(_ => _.Split(" ").Select(int.Parse).ToArray()).ToArray();
    }

    public int[] Row(int row)
    {
         return _matrix[row - 1];
    }

    public int[] Column(int col)
    {
        return _matrix.Select(_ => _[col - 1]).ToArray();
    }
}
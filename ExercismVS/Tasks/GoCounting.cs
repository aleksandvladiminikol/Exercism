namespace Exercism.Tasks;

public class GoCounting
{
    
}

public class GoBoard
{
    // Constants for representing the state of an intersection
    public const int EMPTY = 0;
    public const int BLACK = 1;
    public const int WHITE = 2;

    // 2D array representing the state of each intersection on the board
    private int[,] board;

    // Constructor for creating a GoBoard with a specified size
    public GoBoard(int size)
    {
        board = new int[size, size];
    }

    // Method for determining the territory of each player
    public void DetermineTerritory()
    {
        // Initialize 2D arrays for storing the territory of each player
        int[,] blackTerritory = new int[board.GetLength(0), board.GetLength(1)];
        int[,] whiteTerritory = new int[board.GetLength(0), board.GetLength(1)];

        // Iterate over each intersection on the board
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                // If the intersection is empty, check if it is surrounded by stones of a single color
                if (board[i, j] == EMPTY)
                {
                    // Initialize variables for storing the state of the neighbors
                    int blackNeighbors = 0;
                    int whiteNeighbors = 0;

                    // Check the state of the horizontal and vertical neighbors
                    if (i > 0 && board[i - 1, j] == BLACK)
                    {
                        blackNeighbors++;
                    }

                    if (i < board.GetLength(0) - 1 && board[i + 1, j] == BLACK)
                    {
                        blackNeighbors++;
                    }

                    if (j > 0 && board[i, j - 1] == BLACK)
                    {
                        blackNeighbors++;
                    }

                    if (j < board.GetLength(1) - 1 && board[i, j + 1] == BLACK)
                    {
                        blackNeighbors++;
                    }

                    if (i > 0 && board[i - 1, j] == WHITE)
                    {
                        whiteNeighbors++;
                    }

                    if (i < board.GetLength(0) - 1 && board[i + 1, j] == WHITE)
                    {
                        whiteNeighbors++;
                    }

                    if (j > 0 && board[i, j - 1] == WHITE)
                    {
                        whiteNeighbors++;
                    }

                    if (j < board.GetLength(1) - 1 && board[i, j + 1] == WHITE)
                    {
                        whiteNeighbors++;
                    }

                    // If the intersection is surrounded by stones of a single color, mark it as territory
                    if (blackNeighbors > 0 && whiteNeighbors == 0)
                    {
                        blackTerritory[i, j] = 1;
                    }

                    if (whiteNeighbors > 0 && blackNeighbors == 0)
                    {
                        whiteTerritory[i, j] = 1;
                    }
                }
            }
        }
        
    }
}
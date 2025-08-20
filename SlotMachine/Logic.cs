namespace SlotMachine;

public static class Logic
{
    private const int MinSymbolValue = 1;
    private const int MaxSymbolValue = 4;
    private const int PayoutPerLine = 1;

    public const int MODE_MIDDLE_HORIZONTAL = 1;
    public const int MODE_ALL_HORIZONTALS = 2;
    public const int MODE_ALL_VERTICALS = 3;
    public const int MODE_DIAGONALS = 4;
    public const int MODE_ALL = 5;

    private static readonly Random Rnd = new Random();

    // Fill grid
    public static int[,] Spin(int rows, int cols)
    {
        int[,] grid = new int[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                grid[r, c] = Rnd.Next(MinSymbolValue, MaxSymbolValue + 1);
            }
        }
        return grid;
    }

    // Calculate win
    public static int CalculateProfit(int[,] grid, int mode)
    {
        int profit = 0;
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        // Middle Horizontal Line
        if (mode == MODE_MIDDLE_HORIZONTAL || mode == MODE_ALL)
        {
            int row = rows / 2;
            if (AllEqualInRow(grid, row)) profit += PayoutPerLine;
        }

        // All Horizontal Lines
        if (mode == MODE_ALL_HORIZONTALS || mode == MODE_ALL)
        {
            for (int r = 0; r < rows; r++)
                if (AllEqualInRow(grid, r)) profit += PayoutPerLine;
        }

        // All Vertical Lines
        if (mode == MODE_ALL_VERTICALS || mode == MODE_ALL)
        {
            for (int c = 0; c < cols; c++)
                if (AllEqualInColumn(grid, c)) profit += PayoutPerLine;
        }

        // Diagonals
        if ((mode == MODE_DIAGONALS || mode == MODE_ALL) && rows == cols)
        {
            if (AllEqualInPrimaryDiagonal(grid)) profit += PayoutPerLine;
            if (AllEqualInSecondaryDiagonal(grid)) profit += PayoutPerLine;
        }

        return profit;
    }
    
    private static bool AllEqualInRow(int[,] grid, int row)
    {
        int cols = grid.GetLength(1);
        int first = grid[row, 0];
        for (int c = 1; c < cols; c++)
            if (grid[row, c] != first) return false;
        return true;
    }

    private static bool AllEqualInColumn(int[,] grid, int col)
    {
        int rows = grid.GetLength(0);
        int first = grid[0, col];
        for (int r = 1; r < rows; r++)
            if (grid[r, col] != first) return false;
        return true;
    }

    private static bool AllEqualInPrimaryDiagonal(int[,] grid)
    {
        int size = grid.GetLength(0);
        int first = grid[0, 0];
        for (int i = 1; i < size; i++)
            if (grid[i, i] != first) return false;
        return true;
    }

    private static bool AllEqualInSecondaryDiagonal(int[,] grid)
    {
        int size = grid.GetLength(0);
        int first = grid[0, size - 1];
        for (int i = 1; i < size; i++)
            if (grid[i, size - 1 - i] != first) return false;
        return true;
    }
}

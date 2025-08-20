using SlotMachine;

class Program
{
    static void Main()
    {
        Console.Write("How many rows do you want? ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows < 1)
        {
            Console.WriteLine("Invalid input for rows. Exiting.");
            return;
        }

        Console.Write("How many columns do you want? ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols < 1)
        {
            Console.WriteLine("Invalid input for columns. Exiting.");
            return;
        }

        Console.Write("Please place your bet: ");
        if (!int.TryParse(Console.ReadLine(), out int bet) || bet < 1)
        {
            Console.WriteLine("Invalid bet amount. Exiting.");
            return;
        }

        Console.WriteLine("\nWhich lines do you want to play?");
        Console.WriteLine($"{Logic.MODE_MIDDLE_HORIZONTAL} - Middle Horizontal Line");
        Console.WriteLine($"{Logic.MODE_ALL_HORIZONTALS} - All Horizontal Lines");
        Console.WriteLine($"{Logic.MODE_ALL_VERTICALS} - All Vertical Lines");
        Console.WriteLine($"{Logic.MODE_DIAGONALS} - Diagonal (2 Lines)");
        Console.WriteLine($"{Logic.MODE_ALL} - All Lines");
        Console.Write("Your choice: ");
        if (!int.TryParse(Console.ReadLine(), out int lineChoice))
        {
            Console.WriteLine("Invalid choice. Defaulting to Middle Horizontal Line.");
            lineChoice = Logic.MODE_MIDDLE_HORIZONTAL;
        }

        // Spin und Grid holen
        int[,] grid = Logic.Spin(rows, cols);

        // Grid anzeigen
        Console.WriteLine("\nSlot Machine Result:");
        PrintGrid(grid);

        // Gewinn berechnen
        int profit = Logic.CalculateProfit(grid, lineChoice);
        int total = bet + profit;

        Console.WriteLine($"\nProfit: {profit}");
        Console.WriteLine($"Amount of Money: ${total}");
    }

    private static void PrintGrid(int[,] grid)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write(grid[r, c] + " ");
            }
            Console.WriteLine();
        }
    }
}

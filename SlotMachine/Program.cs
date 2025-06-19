using System;

class SlotMachine
{
    const int minSymbolValue = 1;
    const int maxSymbolValue = 4;
    const int payoutPerLine = 1;

    const int MODE_MIDDLE_HORIZONTAL = 1;
    const int MODE_ALL_HORIZONTALS = 2;
    const int MODE_ALL_VERTICALS = 3;
    const int MODE_DIAGONALS = 4;
    const int MODE_ALL = 5;

    static void Main()
    {
        Random rnd = new Random();

        // User defined grid size
        Console.Write("How many rows do you want? ");
        int numberOfRows = int.Parse(Console.ReadLine());

        Console.Write("How many columns do you want? ");
        int numberOfColumns = int.Parse(Console.ReadLine());

        int[,] grid = new int[numberOfRows, numberOfColumns];

        Console.Write("Please place your bet: ");
        int bet = int.Parse(Console.ReadLine());

        Console.WriteLine("\nWhich lines do you want to play?");
        Console.WriteLine($"{MODE_MIDDLE_HORIZONTAL} - Middle Horizontal Line");
        Console.WriteLine($"{MODE_ALL_HORIZONTALS} - All Horizontal Lines");
        Console.WriteLine($"{MODE_ALL_VERTICALS} - All Vertical Lines");
        Console.WriteLine($"{MODE_DIAGONALS} - Diagonal (2 Lines)");
        Console.WriteLine($"{MODE_ALL} - All Lines");
        Console.Write("Your choice: ");
        int lineChoice = int.Parse(Console.ReadLine());

        Console.WriteLine("\nYou selected:");
        if (lineChoice == MODE_MIDDLE_HORIZONTAL)
            Console.WriteLine("▶ Middle Horizontal Line");
        else if (lineChoice == MODE_ALL_HORIZONTALS)
            Console.WriteLine("▶ All Horizontal Lines");
        else if (lineChoice == MODE_ALL_VERTICALS)
            Console.WriteLine("▶ All Vertical Lines");
        else if (lineChoice == MODE_DIAGONALS)
            Console.WriteLine("▶ Diagonal (2 Lines)");
        else if (lineChoice == MODE_ALL)
            Console.WriteLine("▶ All Lines");
        else
        {
            Console.WriteLine("Invalid choice. Defaulting to Middle Horizontal Line.");
            lineChoice = MODE_MIDDLE_HORIZONTAL;
        }

        // fill grid
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                grid[row, col] = rnd.Next(minSymbolValue, maxSymbolValue + 1);
            }
        }

        // show grid
        Console.WriteLine("\nSlot Machine Result:");
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }

        int profit = 0;

        // Middle Horizontal Line
        if (lineChoice == MODE_MIDDLE_HORIZONTAL || lineChoice == MODE_ALL)
        {
            int row = numberOfRows / 2;
            int first = grid[row, 0];
            bool allEqual = true;
            for (int col = 1; col < numberOfColumns; col++)
            {
                if (grid[row, col] != first)
                {
                    allEqual = false;
                    break;
                }
            }
            if (allEqual) profit += payoutPerLine;
        }

        // All Horizontal Lines
        if (lineChoice == MODE_ALL_HORIZONTALS || lineChoice == MODE_ALL)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                int first = grid[row, 0];
                bool allEqual = true;
                for (int col = 1; col < numberOfColumns; col++)
                {
                    if (grid[row, col] != first)
                    {
                        allEqual = false;
                        break;
                    }
                }
                if (allEqual) profit += payoutPerLine;
            }
        }

        // All Vertical Lines
        if (lineChoice == MODE_ALL_VERTICALS || lineChoice == MODE_ALL)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                int first = grid[0, col];
                bool allEqual = true;
                for (int row = 1; row < numberOfRows; row++)
                {
                    if (grid[row, col] != first)
                    {
                        allEqual = false;
                        break;
                    }
                }
                if (allEqual) profit += payoutPerLine;
            }
        }

        // Diagonals
        if (lineChoice == MODE_DIAGONALS || lineChoice == MODE_ALL)
        {
            // Primary Diagonal (\)
            if (numberOfRows == numberOfColumns)
            {
                int first = grid[0, 0];
                bool allEqual = true;
                for (int i = 1; i < numberOfRows; i++)
                {
                    if (grid[i, i] != first)
                    {
                        allEqual = false;
                        break;
                    }
                }
                if (allEqual) profit += payoutPerLine;

                // Secondary Diagonal (/)
                first = grid[0, numberOfColumns - 1];
                allEqual = true;
                for (int i = 1; i < numberOfRows; i++)
                {
                    if (grid[i, numberOfColumns - 1 - i] != first)
                    {
                        allEqual = false;
                        break;
                    }
                }
                if (allEqual) profit += payoutPerLine;
            }
        }

        int amountOfMoney = bet + profit;

        Console.WriteLine("\nProfit: " + profit);
        Console.WriteLine("Amount of Money: $" + amountOfMoney);
    }
}

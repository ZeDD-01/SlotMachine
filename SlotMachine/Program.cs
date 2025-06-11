using System;
using System.Diagnostics;

class SlotMachine
{
    static void Main()
    {
        const int numberOfRows = 3;
        const int numberOfColumns = 3;
        const int minSymbolValue = 1;
        const int maxSymbolValue = 4;
        const int payoutPerLine = 1;
        
        const string middleHorizontalLine = "1 - Middle Horizontal Line";
        const string allHorizontalLine = "2 - All Horizontal Lines";
        const string allVerticalLine = "3 - All Vertical Lines";
        const string diagonalsTwoLines = "4 - Diagonal (2 Lines)";
        const string allLines = "5 - All Lines";
        
        int[,] grid = new int[numberOfRows, numberOfColumns];
        Random rnd = new Random();
        
        Console.Write("Please place your bet ");
        int bet = int.Parse(Console.ReadLine());
        
        Console.Write("Which lines do you want to play?\n");
        Console.WriteLine(middleHorizontalLine);
        Console.WriteLine(allHorizontalLine);
        Console.WriteLine(allVerticalLine);
        Console.WriteLine(diagonalsTwoLines);
        Console.WriteLine(allLines);
        Console.Write("Your choice: ");
        string lineChoice = Console.ReadLine();

        // Start the Slot Machine
        for (int row = 0; row <numberOfRows ; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                //grid[row, col] = rnd.Next(minSymbolValue, maxSymbolValue +1); 
                //With this line below you can test what happens if the user wins.
                grid[row, col] = 1; 
            }
        }
        
        Console.WriteLine("Slot Machine Result:");
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }

        int profit = 0;

        if (lineChoice == "1" || lineChoice == "5")
        {
            if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2])
            {
                profit += payoutPerLine;
            }
        }
        if (lineChoice == "2" || lineChoice == "5")
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                if (grid[row, 0] == grid[row, 1] && grid[row, 1] == grid[row, 2])
                {
                    profit += payoutPerLine;
                }
            }
        }

        if (lineChoice == "3" || lineChoice == "5")
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                if (grid[0, col] == grid[1, col] && grid[1, col] == grid[2, col])
                {
                    profit += payoutPerLine;
                }
            }
        }
        
        if (lineChoice == "4" || lineChoice == "5")
        {
           
            if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
            {
                profit += payoutPerLine;
            }

            
            if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
            {
                profit += payoutPerLine;
            }
        }
        
        int amountOfMoney = bet;

        if (profit > 0)
        {
            amountOfMoney += profit;
        }
        
        Console.WriteLine("\nProfit: " + profit);
        Console.WriteLine("Amount of Money: $" + amountOfMoney);
    }
}
using System;

class SlotMachine
{
    static void Main()
    {
        int numberOfRows = 3;
        int numberOfColumns = 3;
        int[,] grid = new int[numberOfRows, numberOfColumns];
        Random rnd = new Random();
        
        Console.Write("Please place your bet ");
        int bet = int.Parse(Console.ReadLine());
        
        Console.Write("Which lines do you want to play?\n");
        Console.WriteLine("1 - Middle horizontal line");
        Console.WriteLine("2 - All horizontal lines");
        Console.Write("Your choice: ");
        int lineChoice = int.Parse(Console.ReadLine());

        // Start the Slot Machine
        for (int row = 0; row <numberOfRows ; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                grid[row, col] = rnd.Next(1, 5); 
                //With this line below you can test what happens if the user wins.
                //grid[row, col] = 1; 
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

        if (lineChoice == 1)
        {
            if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2])
            {
                profit +=1;
            }
        }
        else if (lineChoice == 2)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                if (grid[row, 0] == grid[row, 1] && grid[row, 1] == grid[row, 2])
                {
                    profit += 1;
                }
            }
        }
        
        int amountOfMoney = 0;

        if (profit != 0)
        {
            amountOfMoney = bet + profit;
        }
        
        Console.WriteLine("\nProfit: $" + profit);
        Console.WriteLine("Amount of Money: $" + amountOfMoney);
    }
}
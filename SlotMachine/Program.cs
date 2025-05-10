using System;

class SlotMachine
{
    static void Main()
    {
        int numberOfRows = 3;
        int numberOfColumns = 3;
        int[,] grid = new int[numberOfRows, numberOfColumns];
        Random rnd = new Random();

        // Start the Slot Machine
        for (int row = 0; row <numberOfRows ; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                grid[row, col] = rnd.Next(1, 5); 
            }
        }
        
        Console.WriteLine("Slot Machine Ergebnis:");
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
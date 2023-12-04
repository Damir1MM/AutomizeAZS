using System;

class FreePos
{
    bool[][] parkingSpaces;

    public FreePos()
    {

        parkingSpaces = new bool[][]
        {
            new bool[2],
            new bool[2],
            new bool[2],
            new bool[2],
            new bool[4]
        };
    }

    public void CarArrived(int columnNumber, int spaceNumber)
    {
        if (columnNumber >= 1 && columnNumber <= parkingSpaces.Length)
        {
            if (spaceNumber >= 1 && spaceNumber <= parkingSpaces[columnNumber - 1].Length)
            {
                if (!parkingSpaces[columnNumber - 1][spaceNumber - 1])
                {
                    parkingSpaces[columnNumber - 1][spaceNumber - 1] = true;
                    Console.WriteLine($"Место {spaceNumber} на колонке {columnNumber} теперь занято.");
                }
            }
        }
    }
}

class Program
{

}

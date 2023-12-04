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
            else
            {
                Console.WriteLine("Ошибка: Неправильный номер места.");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: Неправильный номер колонки.");
        }
    }

    public void PersonDetected(int columnNumber, int spaceNumber)
    {
        if (columnNumber >= 1 && columnNumber <= parkingSpaces.Length)
        {
            if (spaceNumber >= 1 && spaceNumber <= parkingSpaces[columnNumber - 1].Length)
            {
                if (parkingSpaces[columnNumber - 1][spaceNumber - 1])
                {
                    parkingSpaces[columnNumber - 1][spaceNumber - 1] = false;
                    Console.WriteLine($"Место {spaceNumber} на колонке {columnNumber} теперь свободно.");
                }
                else
                {
                    Console.WriteLine("Ошибка: Место уже свободно.");
                }
            }
        }
        else
        {
            Console.WriteLine("Ошибка: Неправильный номер колонки.");
        }
    }

    public void PrintParkingStatus()
    {
        Console.WriteLine("Статус парковки:");
        for (int i = 0; i < parkingSpaces.Length; i++)
        {
            for (int j = 0; j < parkingSpaces[i].Length; j++)
            {
                string status = parkingSpaces[i][j] ? "Занято" : "Свободно";
                Console.WriteLine($"Место {j + 1} на колонке {i + 1}: {status}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FreePos freePos = new FreePos();

        freePos.CarArrived(1, 1);
        freePos.CarArrived(4, 2);

        freePos.PersonDetected(2, 1);

        freePos.PrintParkingStatus();
    }
}
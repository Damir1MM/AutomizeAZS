﻿using System;

//FreePos-----------------------------------------------------------------------------------------------------------------------------------------
class FreePos
{
    bool[][] parkingSpaces; // Массив для хранения информации о свободных и занятых местах

    public FreePos()
    {
        // Инициализация массива с учетом количества колонок и мест на станции
        parkingSpaces = new bool[][]
        {
            new bool[2], // Бензиновая колонка 1 с 2 местами
            new bool[2], // Бензиновая колонка 2 с 2 местами
            new bool[2], // Бензиновая колонка 3 с 2 местами
            new bool[2], // Дизельная колонка 4 с 2 местами
            new bool[4]  // Электрическая колонка 5 с 4 местами
        };
    }

    public void CarArrived(int columnNumber, int spaceNumber)
    {
        if (columnNumber >= 1 && columnNumber <= parkingSpaces.Length)
        {
            if (spaceNumber >= 1 && spaceNumber <= parkingSpaces[columnNumber - 1].Length)
            {
                if (!parkingSpaces[columnNumber - 1][spaceNumber - 1]) // Проверка, что место свободно
                {
                    parkingSpaces[columnNumber - 1][spaceNumber - 1] = true; // Установка флага "занято" для указанного места
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
                if (parkingSpaces[columnNumber - 1][spaceNumber - 1]) // Проверка, что место занято
                {
                    parkingSpaces[columnNumber - 1][spaceNumber - 1] = false; // Установка флага "свободно" для указанного места
                    Console.WriteLine($"Место {spaceNumber} на колонке {columnNumber} теперь свободно.");
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

// Transaction---------------------------------------------------------------------------------------------------------------------------\

public class Transaction
{
    public DateTime Date { get; set; }              //Дата транзакции
    public decimal Amount { get; set; }             //Сумма(кол-во рублей) транзакции
    public string Description { get; set; }         //Описание транзакции
}

public class Client
{
    private List<Transaction> transactions;         //Список транзакций

    public Client()
    {
        transactions = new List<Transaction>();    //Инициализация списка транзакций
    }

    //Метод добавления транзакции
    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);             
    }

    //Метод получения транзакции
    public List<Transaction> GetTransactions()
    {
        return transactions;                       
    }

}

class Program
{
    static void Main(string[] args)
    {
        //FreePos--------------------------------------------------------------------------------------------------------------

        FreePos freePos = new FreePos(); // Создание объекта автозаправочной станции

        freePos.CarArrived(1, 1); // Прибытие автомобиля на место 1 на бензиновой колонке 1
        freePos.CarArrived(4, 2); // Прибытие автомобиля на место 2 на дизельной колонке 4

        freePos.PersonDetected(2, 1); // Обнаружение человека на месте 1 на бензиновой колонке 1

        freePos.PrintParkingStatus(); // Вывод статуса парковки

        //Transaction----------------------------------------------------------------------------------------------------------

        Client client = new Client();

        // добавление новых транзакций
        client.AddTransaction(new Transaction { Date = DateTime.Now, Amount = 100, Description = "Рублей -- Пополнение счета" });                 
        client.AddTransaction(new Transaction { Date = DateTime.Now.AddDays(-1), Amount = -50, Description = "Рублей -- Оплата за услуги" });

       
        List<Transaction> transactions = client.GetTransactions();   // получение списка всех транзакций

        // вывод списка транзакций
        Console.WriteLine();
        Console.WriteLine("История опираций:");
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine();
            Console.WriteLine("{0} | {1}  {2}", transaction.Date, transaction.Amount, transaction.Description);
        }
    }
}
